using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {

    Vector3 posicao1;
    float contador;
    Brick brick;

    public bool power;

    public Ataque foguin;

    // Use this for initialization
    void Start () {
        //print("funcionando");
        posicao1 = gameObject.GetComponent<Transform>().transform.position;
        foguin.gameObject.GetComponent<Transform>().localScale = new Vector3(3, 3, 3);

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
        if (col.gameObject.tag == "Brick")
        {
            //Destroy(col.gameObject);
            Destroy(col.gameObject);
        }
    }
}
