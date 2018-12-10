using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    GameObject go;
    // Use this for initialization
    void Start () {
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = Quad.Create(60f,26f); // Card.width, Card.height);

        this.gameObject.GetComponent<MeshFilter>().mesh = mesh;
        this.gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Material/Green");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
