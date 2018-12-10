using UnityEngine;
using System.Collections;

public class Quad 
{
    public static Mesh Create(float width = 1.0f, float height = 1.0f)
    {
        Mesh mesh = new Mesh();
        mesh.name = "Quad";

        mesh.vertices = new Vector3[]
        {
            /*
            new Vector3(-width,  height, 0), // 0
            new Vector3( width,  height, 0), // 1
            new Vector3( width, -height, 0), // 2
            new Vector3(-width, -height, 0), // 3
            */
            new Vector3(-width,  0, height), // 0
            new Vector3( width,  0, height), // 1
            new Vector3( width, 0, -height), // 2
            new Vector3(-width, 0, -height), // 3

        };

        mesh.uv = new Vector2[]
        {
            Vector2.up,
            Vector2.one,
            Vector2.right,
            Vector2.zero
        };

        mesh.triangles = new int[]
        {
            0, 1, 2,
            0, 2, 3
        };

        mesh.RecalculateNormals();

        return mesh;
    }
}
