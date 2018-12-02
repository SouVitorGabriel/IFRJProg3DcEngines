using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public Bomberman player;
    public Bomba bomba;
    public int municao, muniMax;
    public float contador, cont;
    public bool infinity = false;

    // Use this for initialization
    void Start () {

        municao = 1;
        muniMax = municao;
        
        contador = 4f;
        this.gameObject.AddComponent<NavMeshAgent>();

        cont = 4f;

    }
	
	// Update is called once per frame
	void Update () {

        this.gameObject.GetComponent<NavMeshAgent>().destination = player.transform.position;

        if (infinity)
        {
            if (municao > 0 & Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bomba, transform.position, Quaternion.identity);

                municao--;
            }

            if (municao <= 0)
            {
                municao = muniMax;
            }
            cont -= Time.deltaTime;
            if (cont <= 0)
                infinity = false;
        }
        else
        {

            if (municao < 1)
            {
                contador -= Time.deltaTime;
            }

            if (contador <= 0)
            {
                municao = 1;
                contador = 4;
            }
        }
    }

    void OnTriggerEnter (Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Instantiate(bomba, transform.position, Quaternion.identity);
            municao = 0;
        }

        

        if (coll.gameObject.CompareTag("Bomba"))
        {
            Destroy(gameObject);
            print("dead");
        }


    }
}
