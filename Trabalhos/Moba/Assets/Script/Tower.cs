using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    // Use this for initialization
    public enum Type
    {
        FRONT,
        BACK
    };
    Type tipo;

    GameObject mobManager;
    void Start () {
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = Cube.Create(0.5f, 0.5f, 3); // Card.width, Card.height);

        this.gameObject.GetComponent<MeshFilter>().mesh = mesh;
        this.gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Material/Blue");

        mobManager = GameObject.Find("MobManager");
        mobManager.GetComponent<MobManager>().SpawnMob(3, new Vector3(6.718449f, 10.32226f, -4.360453f), this.GetComponent<Transform>().transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
	}
}
