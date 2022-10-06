using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshWindow : EditorWindow
{
    private Toggle toggle;

    private static GameObject meshRenderer;

    [MenuItem("Tools/Mesh")]
    public static void ShowMeshWindow()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<MeshWindow>();
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
        EditorApplication.playModeStateChanged += PlayModeStateChanged;
    }

    void Awake()
    {
        //toggle = new Toggle("Test Toggle") { name = "My Toggle" };
        //rootVisualElement.Add(toggle);

        SetupRenderer();
    }

    void OnDestroy()
    {
        DestroyRenderer();
    }

    private static GameObject SetupRenderer()
    {
        meshRenderer = new GameObject("RenderMeshInSceneView");
        meshRenderer.hideFlags = HideFlags.DontSave;
        meshRenderer.AddComponent<RenderMeshInSceneView>();
        RenderMeshInSceneView rmisv = meshRenderer.GetComponent<RenderMeshInSceneView>();
        rmisv.Setup();
        return meshRenderer;
    }

    private static void DestroyRenderer()
    {
        DestroyImmediate(meshRenderer);
    }

    private static void PlayModeStateChanged(PlayModeStateChange state)
    {
        //Debug.Log(state);
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            DestroyRenderer();
            SetupRenderer();
        }
        else if (state == PlayModeStateChange.EnteredEditMode)
        {
            DestroyRenderer();
            SetupRenderer();
        }
    }
}

