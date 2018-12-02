using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    float timer;
    Bomberman player;

	// Use this for initialization
	void Start () {

        timer = 1f;
	}
	
	// Update is called once per frame
	void Update () {

        

    }

    void OnTriggerStay(Collider coll)
    {
        if (gameObject.CompareTag("Bomba"))
        {
            Destroy(this);
            print("destroyed");
        }

        /*if (Input.GetKey(KeyCode.Space))
        {
            timer -= Time.deltaTime;

        }
        if (timer < 1)
        {

            Destroy(this.gameObject);
            timer = 1;
        }*/
    }
}
