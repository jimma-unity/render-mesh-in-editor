using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshWindow : EditorWindow
{
    private static GameObject meshRenderer;

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
        RenderMeshInSceneView rmisv = meshRenderer.GetComponent<RenderMeshInSceneView>();
        rmisv.CreateGUI(rootVisualElement);
    }

    private void OnGUI()
    {
    }

    void Awake()
    {
        SetupRenderer();
    }

    void OnDestroy()
    {
        DestroyRenderer();
    }

    private void Update()
    {
    }

    private static void SetupRenderer()
    {
        if (meshRenderer == null)
        {
            meshRenderer = new GameObject("RenderMeshInSceneView");
            meshRenderer.hideFlags = HideFlags.DontSave;
            meshRenderer.AddComponent<RenderMeshInSceneView>();
            RenderMeshInSceneView rmisv = meshRenderer.GetComponent<RenderMeshInSceneView>();

            GameObject go = (GameObject)Instantiate(Resources.Load("VertexColorCube"));
            Material mat = new Material(go.GetComponent<Renderer>().sharedMaterial);
            mat.enableInstancing = true;
            DestroyImmediate(go);
            rmisv.Setup(mat);
        }
    }

    private static void DestroyRenderer()
    {
        DestroyImmediate(meshRenderer);
        meshRenderer = null;
    }

    private static void PlayModeStateChanged(PlayModeStateChange state)
    {
        Debug.Log(state);
        //if (state == PlayModeStateChange.ExitingEditMode)
        //{
        //    DestroyRenderer();
        //    SetupRenderer();
        //}
        //else
        if (state == PlayModeStateChange.EnteredEditMode)
        {
            DestroyRenderer();
            SetupRenderer();
        }
    }
}

