using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

    Vector3 posicao1;
    float contador;
    Brick brick;


    // Use this for initialization
    void Start () {
        //print("funcionando");
        posicao1 = gameObject.GetComponent<Transform>().transform.position;
        contador = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        contador -= 1 * Time.deltaTime;


        if (contador < 0)
        {
            

            Destroy(this.gameObject);
        }

    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Brick")
        {
            //Destroy(col.gameObject);
            Destroy(brick.gameObject);
        }
    }
}
