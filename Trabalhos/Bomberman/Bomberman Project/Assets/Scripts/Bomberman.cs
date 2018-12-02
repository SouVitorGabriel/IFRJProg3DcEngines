using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour {

    float speed = 0.5f;
    GameObject[] bomb;
    public Bomba bomba;
    public int municao;
    float contador;

	// Use this for initialization
	void Start () {
        municao = 1;
        contador = 4f;



	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, 2.8f, transform.position.z + speed);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, 2.8f, transform.position.z - speed);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, 2.8f, transform.position.z);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90, transform.rotation.z));
        }
		
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, 2.8f, transform.position.z);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -90, transform.rotation.z));
        }

        if (municao > 0 & Input.GetKeyDown(KeyCode.Space))
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

        
	}

    void OnTriggerStay (Collider coll)
    {
        if (coll.gameObject.CompareTag("Bomba"))
        {
            Destroy(this.gameObject);
            print("dead");
            UnityEngine.SceneManagement.SceneManager.LoadScene("over");
        }


    }
}
