using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public Bomberman player;
    public Bomba bomba;
    int municao;
    float contador;

    // Use this for initialization
    void Start () {

        municao = 1;
        contador = 4f;
        this.gameObject.AddComponent<NavMeshAgent>();
        
    }
	
	// Update is called once per frame
	void Update () {

        this.gameObject.GetComponent<NavMeshAgent>().destination = player.transform.position;
    }

    void OnTriggerEnter (Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Instantiate(bomba, transform.position, Quaternion.identity);
            municao = 0;
        }

        if (municao < 1)
        {
            contador -= Time.deltaTime;
        }

        if (contador < 1)
        {
            municao = 1;
            contador = 4;
        }

        if (coll.gameObject.CompareTag("Bomba"))
        {
            Destroy(gameObject);
            print("dead");
        }
    }
}
