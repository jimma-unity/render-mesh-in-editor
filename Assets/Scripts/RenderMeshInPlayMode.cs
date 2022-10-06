using UnityEditor.ShaderGraph;
using UnityEngine;

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

    void Update()
    {
        int layer = 0;
        Camera camera = null;
        int submeshIndex = 0;
        MaterialPropertyBlock matPropBlock = null;
        bool castShadows = false;

        Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, layer, camera, submeshIndex, matPropBlock, castShadows);

        Graphics.DrawMesh(mesh, offset, Quaternion.identity, material, layer, camera, submeshIndex, matPropBlock, castShadows);
    }
}
