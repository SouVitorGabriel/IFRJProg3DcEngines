using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {

    float contador;
    public Ataque ataque;
    Vector3 posicao;

	// Use this for initialization
	void Start () {
        contador = 2f;
        posicao = gameObject.GetComponent<Transform>().transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        
        
        contador -= 1 * Time.deltaTime;


        if (contador < 0)
        {
            //print("funcionando");
            Instantiate(ataque, posicao, Quaternion.identity);

            Destroy(this.gameObject);
        }
	}
}
