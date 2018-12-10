using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour {
    float hp, atk, def, range;
    public enum Type
    {
        RANGE,
        MELEE
    };
    Type tipo;
    GameObject go;
    Mesh capsule;
    // Use this for initialization
    void Start () {


        /*
        capsule = go.GetComponent<Mesh>();
        Destroy(go);

        
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();
        */
        this.gameObject.AddComponent<NavMeshAgent>();
        this.gameObject.GetComponent<NavMeshAgent>().destination = (new Vector3(0, 0, 5));
        //this.gameObject.GetComponent<MeshFilter>().mesh = capsule;
        //.gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Material/Mob");


    }
	/*
    public void Values(Vector3 destination, Type type, float hp =100, float atk = 1, float def = 1)
    {
        this.go.GetComponent<NavMeshAgent>().SetDestination(destination);
        this.tipo = type;
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        if(tipo == Type.RANGE)
        {
            this.range = 2;
        }
        else
        {
            this.range = 1;
        }
    }*/
	// Update is called once per frame
	void Update () {
		
	}
}
