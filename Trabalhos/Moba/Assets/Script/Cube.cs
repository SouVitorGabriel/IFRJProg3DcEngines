using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube
{ 
    
    public static Mesh Create(float width = 0.5f, float height = 0.5f, float h = 4)
    {
        Mesh mesh = new Mesh();
        mesh.name = "Cube";

        mesh.vertices = new Vector3[]
        {
            //Topo
            new Vector3(-width, h, height), // 0
            new Vector3( width, h, height), // 1
            new Vector3( width, h, -height), // 2
            new Vector3(-width, h, -height), // 3
            
            //base
            new Vector3(-width,  0, height), // 4
            new Vector3( width,  0, height), // 5
            new Vector3( width, 0, -height), // 6
            new Vector3(-width, 0, -height), // 7

            

        };

        mesh.uv = new Vector2[]
        {
            Vector2.up,
            Vector2.one,
            Vector2.right,
            Vector2.zero,
            Vector2.up,
            Vector2.one,
            Vector2.right,
            Vector2.zero
        };

        mesh.triangles = new int[]
        {
            0, 1, 2,//topo
            0, 2, 3,
            
            6,5,4, //base
            6,4,7,

            3,2,6,//frente
            3,6,7,

            2,1,5,//esquerda
            2,5,6,

            1,4,5,//fundo
            0,4,1, 

            0,3,4,//direita
            3,7,4

        };

        mesh.RecalculateNormals();

        return mesh;
    }
}
