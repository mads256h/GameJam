using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float BulletLifetime = 1f;
    private float timer;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        timer += Time.deltaTime;
        
        //Move forward
        transform.Translate(Vector3.up * 0.25f);
        
        //Kill after X seconds
        if (timer > BulletLifetime)
        {
            Destroy(gameObject);
        }
    }
}
