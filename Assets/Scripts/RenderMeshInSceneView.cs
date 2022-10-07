#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RenderMeshInSceneView : MonoBehaviour
{
    private Mesh mesh;
    private Material material;
    private Toggle toggle;

    public void Setup(Material mat)
    {
        mesh = CreateMesh.CreatePlane();
        material = mat;
        // This doesn't work (if you assign a material to a GameObject in-editor it works, if you create it in script here it doesn't).
        // Seems to be a bug when you create a Material in script this way.
        //Shader shader = Shader.Find("Shader Graphs/VertexColor");
        //if (shader != null)
        //{
        //    material = new Material(shader);
        //}

        //SceneView.duringSceneGui += OnSceneGUI;
    }
    public void CreateGUI(VisualElement rootVisualElement)
    {
        toggle = new Toggle("Render Mesh") { name = "RenderMesh" };
        toggle.RegisterValueChangedCallback(OnToggleValueChanged);
        rootVisualElement.Add(toggle);
    }

    void OnDestroy()
    {
        toggle.UnregisterValueChangedCallback(OnToggleValueChanged);
    }

    void LogPasses()
    {
        for (int i = 0; i < material.passCount; ++i)
            Debug.Log(material.GetPassName(i));
    }

    private void OnToggleValueChanged(ChangeEvent<bool> evt)
    {
        //Debug.Log(toggle.value);
        // Force repaint of SceneView otherwise Mesh will only appear/disappear once you Mouse over the SceneView window.
        EditorWindow view = EditorWindow.GetWindow<SceneView>();
        view.Repaint();
    }

    void OnDrawGizmos()
    {
        if (toggle != null && toggle.value && mesh != null && material != null)
        {
            material.SetPass(0);
            Graphics.DrawMeshNow(mesh, Vector3.zero, Quaternion.identity);
        }
    }
}

#endif
