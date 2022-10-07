using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class RenderMeshInPlayMode : MonoBehaviour
{
    public Material material;
    private Mesh mesh;
    private Material matty;
    private Vector3 offset;

    void Start()
    {
        mesh = CreateMesh.CreatePlane();
        Shader shader = Shader.Find("Shader Graphs/VertexColor");
        if (shader != null)
        {
            matty = new Material(shader);
            //matty.CopyPropertiesFromMaterial(material);
        }
        offset = new Vector3(0, 1, 0);
    }

    void OnDrawGizmos()
    {
        //if (mesh && material)
        //{
        //    material.SetPass(0);
        //    Graphics.DrawMeshNow(mesh, Vector3.zero, Quaternion.identity);
        //}

        //Matrix4x4[] matrices = new Matrix4x4[] { Matrix4x4.identity };
        //Graphics.DrawMeshInstanced(mesh, 0, material, matrices, 1);
        //Graphics.DrawMeshInstancedProcedural(mesh, 0, material, mesh.bounds, 1);
    }

    void Update()
    {
        int layer = 0;
        Camera camera = null;
        int submeshIndex = 0;
        MaterialPropertyBlock matPropBlock = null;
        bool castShadows = false;

        //Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, layer, camera, submeshIndex, matPropBlock, castShadows);

        //Graphics.DrawMesh(mesh, offset, Quaternion.identity, material, layer, camera, submeshIndex, matPropBlock, castShadows);
    }
}
