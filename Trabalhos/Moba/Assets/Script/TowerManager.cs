using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {
    GameObject[] towerObjects;
    // Use this for initialization
    void Start () {
        towerObjects = new GameObject[12];
        for (int i = 0; i < towerObjects.Length; i++)
        {
            towerObjects[i] = new GameObject("Tower" + (i + 1), typeof(Tower));
            
        }
        towerObjects[0].GetComponent<Transform>().Translate(-13, 0, 11);
        towerObjects[1].GetComponent<Transform>().Translate(13, 0, 11);

        towerObjects[2].GetComponent<Transform>().Translate(-6, 0, 11);
        towerObjects[3].GetComponent<Transform>().Translate(6, 0, 11);


        towerObjects[4].GetComponent<Transform>().Translate(-13, 0, 0);
        towerObjects[5].GetComponent<Transform>().Translate(13, 0, 0);

        towerObjects[6].GetComponent<Transform>().Translate(-6, 0, 0);
        towerObjects[7].GetComponent<Transform>().Translate(6, 0, 0);


        towerObjects[8].GetComponent<Transform>().Translate(-13, 0, -11);
        towerObjects[9].GetComponent<Transform>().Translate(13, 0, -11);

        towerObjects[10].GetComponent<Transform>().Translate(-6, 0, -11);
        towerObjects[11].GetComponent<Transform>().Translate(6, 0, -11);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
