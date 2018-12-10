using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobManager : MonoBehaviour {
    List<GameObject> mobList;
	// Use this for initialization
	void Start () {
        mobList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnMob(int qtd, Vector3 destino, Vector3 position)
    {
        for (int i = 0; i < 3; i++)
        {
            //mobList.Add(new GameObject("Mob" + (i + 1), typeof(Mob)));
            mobList.Add(GameObject.CreatePrimitive(PrimitiveType.Capsule));
        }

        foreach (GameObject g in mobList)
        {
            //g.AddComponent<Mob>();
            g.AddComponent<NavMeshAgent>();
            g.GetComponent<NavMeshAgent>().destination = (new Vector3(0, 0, 5));
            g.GetComponent<Transform>().Translate(position+Vector3.up);
            g.GetComponent<NavMeshAgent>().SetDestination(new Vector3(6.718449f, 10.32226f, -4.360453f));
        }
    }
}
