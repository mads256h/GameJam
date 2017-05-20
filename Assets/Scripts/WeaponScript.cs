using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public GameObject Bullet;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        if (Input.GetButton("joystick button 5")||Input.GetMouseButtonDown(1))
        {
            GameObject Projectile = Instantiate(Bullet, transform);
        }
	}
}
