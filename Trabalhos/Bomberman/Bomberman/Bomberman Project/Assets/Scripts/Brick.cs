using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    float timer;
    Bomberman player;

    // declaracao
    int p;
    [SerializeField] private GameObject p1, p2;

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
            //na funçao que destroi o o brick
            p = 0;
            
            p = Random.Range(0, 5);

            if (p == 1)
            {
                Instantiate(p1, this.gameObject.transform.position, Quaternion.identity);
            }

            if (p == 2)
            {
                Instantiate(p2, this.gameObject.transform.position, Quaternion.identity);
            }
            //fim

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
    public void SpawnPowerUp()
    {
        p = 0;
        //abaixo do compareTag("Bomba")
        p = Random.Range(0, 5);

        if (p == 1)
        {
            Instantiate(p1, this.gameObject.transform.position, Quaternion.identity);
        }

        if (p == 2)
        {
            Instantiate(p2, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
