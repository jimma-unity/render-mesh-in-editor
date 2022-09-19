using UnityEngine;

public class RenderMeshInPlayMode : MonoBehaviour
{
    public Material material;
    private Mesh mesh;

    void CreateMesh()
    {
        // Unity is left-handed Y is up, +ve Z is forward. Winding is Clockwise.
        mesh = new Mesh();
        mesh.vertices = new[]{
            new Vector3(-1, 0, -1),
            new Vector3(-1, 0,  1),
            new Vector3( 1, 0,  1),
            new Vector3( 1, 0, -1)
        };
        mesh.triangles = new[]{
            0,1,2,0,2,3
        };
        mesh.colors = new[]{
            Color.blue,
            Color.blue,
            Color.blue,
            Color.blue
        };
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateMesh();
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

    void OnDrawGizmos()
    {
        if (mesh == null)
            CreateMesh();

        Gizmos.color = Color.blue;
        Gizmos.DrawMesh(mesh);
    }
}
