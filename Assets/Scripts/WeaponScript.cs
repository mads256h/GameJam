using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public GameObject Bullet;

    public Transform Player;

    public float Cooldown = 0.5f;

    private float timer = 0f;

    void Start()
    {
        Player = GetComponent<Transform>();
    }

    void Update ()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer >= Cooldown)
        {
            Vector3 rotation = Player.rotation.eulerAngles;
            rotation.y -= 90f;
            Instantiate(Bullet, Player.position, Quaternion.Euler(rotation));
            timer = 0f;
        }
	}
}
