using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour {
    
    
	// Use this for initialization
	void Start () {
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = Cube.Create(1.5f,1.5f,4); // Card.width, Card.height);

        this.gameObject.GetComponent<MeshFilter>().mesh = mesh;
        this.gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Material/Red");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
