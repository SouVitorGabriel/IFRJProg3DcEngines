using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexusManager : MonoBehaviour
{
    GameObject[] nexusObject;

	// Use this for initialization
	void Start () {
        nexusObject = new GameObject[2];
        for (int i = 0; i < 2; i++)
        {
            nexusObject[i] = new GameObject("Nexus"+i+1, typeof(Nexus));
            print(i);
            
        }
        nexusObject[0].GetComponent<Transform>().Translate(-25.5f, 0, 0);
        nexusObject[1].GetComponent<Transform>().Translate(25.5f, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
