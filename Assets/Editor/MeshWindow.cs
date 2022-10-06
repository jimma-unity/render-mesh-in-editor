using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshhWindow : EditorWindow
{
    private GameObject meshRenderer;
    private Toggle toggle;

    [MenuItem("Tools/Mesh")]
    public static void ShowMeshWindow()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<MeshhWindow>();
        wnd.titleContent = new GUIContent("Mesh");
    }

    void Awake()
    {
        toggle = new Toggle("Test Toggle") { name = "My Toggle" };
        rootVisualElement.Add(toggle);

        meshRenderer = new GameObject("RenderMeshInSceneView");
        meshRenderer.AddComponent<RenderMeshInSceneView>();
        RenderMeshInSceneView rmisv = meshRenderer.GetComponent<RenderMeshInSceneView>();
        rmisv.Setup();
    }

    void OnDestroy()
    {
        DestroyImmediate(meshRenderer);
        meshRenderer = null;
    }
}

