using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBomb : MonoBehaviour {

    public Ataque fire;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            fire.transform.localScale = new Vector3(6, 2, 6);

            Destroy(this.gameObject);
        }
    }
}
