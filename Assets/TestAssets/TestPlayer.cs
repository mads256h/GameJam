using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour {


	void Start ()
    {
		
	}
	

	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 0.1f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
