
using UnityEngine;

public static class CreateMesh
{
    public static Mesh CreatePlane()
    {
        // Unity is left-handed Y is up, +ve Z is forward. Winding is Clockwise.
        Mesh mesh = new Mesh();
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

        return mesh;
    }
}
