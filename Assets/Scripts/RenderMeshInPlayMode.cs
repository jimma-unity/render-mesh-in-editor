using UnityEngine;

public class RenderMeshInPlayMode : MonoBehaviour
{
    public Material material;
    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = CreateMesh.CreatePlane();
    }

    // Update is called once per frame
    void Update()
    {
        int layer = 0;
        Camera camera = null;
        int submeshIndex = 0;
        MaterialPropertyBlock matPropBlock = null;
        bool castShadows = false;

        Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, layer, camera, submeshIndex, matPropBlock, castShadows);
    }
}
