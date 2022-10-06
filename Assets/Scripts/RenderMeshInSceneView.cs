#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public class RenderMeshInSceneView : MonoBehaviour
{
    private Mesh mesh;
    private Material material;

    public void Setup()
    {
        mesh = CreateMesh.CreatePlane();
        
        GameObject go = (GameObject)Instantiate(Resources.Load("VertexColorCube"));
        material = new Material(go.GetComponent<Renderer>().sharedMaterial);
        material.enableInstancing = true;
        DestroyImmediate(go);
        // This doesn't work (if you assign a material to a GameObject in-editor it works, if you create it in script here it doesn't).
        // Seems to be a bug when you create a Material in script this way.
        //Shader shader = Shader.Find("Shader Graphs/VertexColor");
        //if (shader != null)
        //{
        //    material = new Material(shader);
        //}

        SceneView.duringSceneGui += OnSceneGUI;
    }

    void LogPasses()
    {
        for (int i = 0; i < material.passCount; ++i)
            Debug.Log(material.GetPassName(i));
    }

    void OnDrawGizmos()
    {
        material.SetPass(0);
        Graphics.DrawMeshNow(mesh, Vector3.zero, Quaternion.identity);

        //Matrix4x4[] matrices = new Matrix4x4[] { Matrix4x4.identity };
        //Graphics.DrawMeshInstanced(mesh, 0, material, matrices, 1);
        //Graphics.DrawMeshInstancedProcedural(mesh, 0, material, mesh.bounds, 1);
    }

    void OnSceneGUI(SceneView view)
    {
        EditorUtility.SetDirty(view);
    }
}

#endif
