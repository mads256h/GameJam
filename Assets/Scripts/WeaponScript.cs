using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public GameObject Bullet;
    public float FireRate = 1f;
    private float timer;
    private int bulletCounter;

    void Start ()
    {
		
	}
	

	void Update ()
    {
        //If Fire button is pressed and timer is > fire rate -- Shoot
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > FireRate)
        {
            GameObject Projectile = Instantiate(Bullet, transform);
            Projectile.name = "Projectile " + bulletCounter;
            bulletCounter++;
            timer = 0;
        }
	}
}
