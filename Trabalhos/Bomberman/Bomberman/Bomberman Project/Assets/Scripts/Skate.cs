using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skate : MonoBehaviour {

    public Bomberman player;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.speed += 0.5f;
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<NavMeshAgent>().speed += 2f;
            Destroy(this.gameObject);
        }   
    }
}
