using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    GameObject[] mapManager;
    Vector3[] position;
	// Use this for initialization
	void Start () {
        mapManager = new GameObject[12];
        position = new Vector3[12];

        position[0] = new Vector3(-18,0, 4.5f);
        position[1] = new Vector3(-18, 0, -4.5f);

        position[2] = new Vector3(-9.25f,0,5.5f);
        position[3] = new Vector3(-9.25f,0,-5.5f);
        
        position[4] = new Vector3(-2.5f,0,5.5f);
        position[5] = new Vector3(-2.5f, 0, -5.5f);

        position[6] = new Vector3(18, 0, 4.5f);
        position[7] = new Vector3(18, 0, -4.5f);

        position[8] = new Vector3(9.25f, 0, 5.5f);
        position[9] = new Vector3(9.25f, 0, -5.5f);

        position[10] = new Vector3(2.5f, 0, 5.5f);
        position[11] = new Vector3(2.5f, 0, -5.5f);

        for (int i=0; i<mapManager.Length; i++)
        {
            mapManager[i] = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            mapManager[i].GetComponent<Transform>().localScale = new Vector3(5,5,5);
            mapManager[i].GetComponent<Transform>().Translate(position[i]);
            mapManager[i].GetComponent<MeshRenderer>().material = (Material)Resources.Load("Material/PauDurasço");
        }

        mapManager[4].GetComponent<Transform>().localScale = new Vector3(3, 3, 3);
        mapManager[5].GetComponent<Transform>().localScale = new Vector3(3, 3, 3);
        mapManager[10].GetComponent<Transform>().localScale = new Vector3(3, 3, 3);
        mapManager[11].GetComponent<Transform>().localScale = new Vector3(3, 3, 3);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
