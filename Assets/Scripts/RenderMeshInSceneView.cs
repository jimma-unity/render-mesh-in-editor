using UnityEngine;

public class RenderMeshInSceneView : MonoBehaviour
{
    private Mesh mesh;

    public void Setup()
    {
        mesh = CreateMesh.CreatePlane();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawMesh(mesh);
    }
}
