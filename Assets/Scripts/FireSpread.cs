using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour {

    public bool OnFire;
    void Start ()
    {

	}
	

	void Update ()
    {
        if (OnFire)
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<FireSpread>() != null)
        {
            collision.gameObject.GetComponent<FireSpread>().OnFire = true;
        }
    }

}

