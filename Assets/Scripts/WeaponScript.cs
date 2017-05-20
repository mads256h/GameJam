using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Consts.PlayerID PlayerID = Consts.PlayerID.One;

    public Bullet bullet;

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
        bool shoot = false;
        switch (PlayerID)
        {
            case Consts.PlayerID.One:
                shoot = Input.GetButton("JFire1");
                break;

            case Consts.PlayerID.Two:
                shoot = Input.GetButton("JFire2");
                break;
        }

        if (shoot && timer >= Cooldown)
        {
            Vector3 rotation = Player.rotation.eulerAngles;
            rotation.y -= 90f;
            Instantiate(bullet, Player.position, Quaternion.Euler(rotation));
            timer = 0f;
        }
	}
}
