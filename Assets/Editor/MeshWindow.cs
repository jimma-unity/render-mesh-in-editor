using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshWindow : EditorWindow
{
    private GameObject meshRenderer;

    [MenuItem("Tools/Mesh")]
    public static void ShowMeshWindow()
    {
        // This method is called when the user selects the menu item in the Editor
        MeshWindow wnd = GetWindow<MeshWindow>();
        wnd.titleContent = new GUIContent("Mesh");
    }

    private void OnEnable()
    {
        EditorApplication.playModeStateChanged -= PlayModeStateChanged;
        EditorApplication.playModeStateChanged += PlayModeStateChanged;
    }

    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= PlayModeStateChanged;
        //EditorApplication.playModeStateChanged += PlayModeStateChanged;
    }

    void CreateGUI()
    {
        DestroyRenderer();
        SetupRenderer();
    }

    void OnDestroy()
    {
        DestroyRenderer();
    }

    private void SetupRenderer()
    {
        meshRenderer = new GameObject("RenderMeshInSceneView");
        meshRenderer.hideFlags = HideFlags.DontSave;

        RenderMeshInSceneView rmisv = meshRenderer.AddComponent<RenderMeshInSceneView>();
        rmisv.Setup();
        rmisv.CreateGUI(rootVisualElement);
    }

    private void DestroyRenderer()
    {
        RenderMeshInSceneView rmisv = meshRenderer ? meshRenderer.GetComponent<RenderMeshInSceneView>() : null;
        if (rmisv != null)
        {
            rmisv.DestroyGUI(rootVisualElement);
            DestroyImmediate(meshRenderer);
            meshRenderer = null;
        }
    }

    private static void PlayModeStateChanged(PlayModeStateChange state)
    {
        //Debug.Log(state);
        MeshWindow wnd = GetWindow<MeshWindow>();
        //if (state == PlayModeStateChange.ExitingEditMode)
        //{
        //    DestroyRenderer();
        //    SetupRenderer();
        //}
        //else
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            wnd.DestroyRenderer();
            wnd.SetupRenderer();
        }
    }
}

