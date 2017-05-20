using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public GameObject Bullet;
    public float FireRate = 1f;
    private float timer;
    private int bulletCounter;

<<<<<<< HEAD
    void Start ()
=======
    public Transform Player;

    public float Cooldown = 0.5f;

    private float timer = 0f;

    void Start()
>>>>>>> Bullet
    {
        Player = GetComponent<Transform>();
    }

    void Update ()
    {
<<<<<<< HEAD
        //If Fire button is pressed and timer is > fire rate -- Shoot
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer > FireRate)
        {
            GameObject Projectile = Instantiate(Bullet, transform);
            Projectile.name = "Projectile " + bulletCounter;
            bulletCounter++;
            timer = 0;
=======
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= Cooldown)
        {
            Vector3 rotation = Player.rotation.eulerAngles;
            rotation.y -= 90f;
            Instantiate(Bullet, Player.position, Quaternion.Euler(rotation));
            timer = 0f;
>>>>>>> Bullet
        }
	}
}
