using UnityEditor;
using UnityEngine;

public class MeshhWindow : EditorWindow
{
    private GameObject meshRenderer;

    [MenuItem("Tools/Mesh")]
    public static void ShowMeshWindow()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<MeshhWindow>();
        wnd.titleContent = new GUIContent("Mesh");
    }

    void OnEnable()
    {
        meshRenderer = new GameObject();
        meshRenderer.AddComponent<RenderMeshInSceneView>();
        RenderMeshInSceneView rmisv = meshRenderer.GetComponent<RenderMeshInSceneView>();
        rmisv.Setup();
        //Debug.Log("ENABLE");
    }

    void OnDisable()
    {
        DestroyImmediate(meshRenderer);
        //Debug.Log("DISABLE");
    }
}

