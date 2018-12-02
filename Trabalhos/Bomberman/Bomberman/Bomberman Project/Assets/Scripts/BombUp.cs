using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUp : MonoBehaviour {
    
    public Bomberman player;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.cont += 4f;
            player.infinity = true;
            Debug.Log("Munição: "+ player.municao);
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
