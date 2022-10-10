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
        //RenderMeshInSceneView rmisv = meshRenderer.GetComponent<RenderMeshInSceneView>();
        //rmisv.CreateGUI(rootVisualElement);
    }

    private void OnGUI()
    {
    }

    void Awake()
    {
        //SetupRenderer();
    }

    void OnDestroy()
    {
        DestroyRenderer();
    }

    private void Update()
    {
    }

    private void SetupRenderer()
    {
        //RenderMeshInSceneView rmisv = new RenderMeshInSceneView();

        //if (rmisv == null)
        {
            meshRenderer = new GameObject("RenderMeshInSceneView");
            meshRenderer.hideFlags = HideFlags.DontSave;

            GameObject go = (GameObject)Instantiate(Resources.Load("VertexColorCube"));
            Material mat = new Material(go.GetComponent<Renderer>().sharedMaterial);
            mat.enableInstancing = true;
            DestroyImmediate(go);

            RenderMeshInSceneView rmisv = meshRenderer.AddComponent<RenderMeshInSceneView>();
            rmisv.Setup(mat);
            rmisv.CreateGUI(rootVisualElement);
        }
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
        Debug.Log(state);
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

