using UnityEngine;

public class RenderMeshInSceneView : MonoBehaviour
{
    private Mesh mesh;

    void OnDrawGizmos()
    {
        if (mesh == null)
            mesh = CreateMesh.CreatePlane();

        Gizmos.color = Color.blue;
        Gizmos.DrawMesh(mesh);
    }
}
