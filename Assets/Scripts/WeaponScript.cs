﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public Consts.PlayerID PlayerID = Consts.PlayerID.One;

    public Bullet bullet;

    public GameObject Bomb;

    public Vector3 BombStrength = new Vector3(0, 0, 1f);

    public CapsuleCollider meeleRange;

    public int meeleDamage = 100;

    public Sprite Magic;

    public Animator muzzleFlash;

    public Transform player;

    private Player playerScript;

    public float Cooldown = 0.5f;

    private float timer = 0f;

    void Start()
    {
        player = GetComponent<Transform>();
        playerScript = GetComponent<Player>();

        Player.Player1Type = Consts.PlayerType.Knight;
    }

    void Update()
    {

        if (playerScript.isDead)
            return;

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
        if (shoot && timer >= Cooldown && PlayerID == Consts.PlayerID.One)
        {
            switch (Player.Player1Type)
            {
                case Consts.PlayerType.LongShot:
                    muzzleFlash.Play("MuzzleFlash");
                    Vector3 rotation = player.rotation.eulerAngles;
                    rotation.y -= 90f;
                    Instantiate(bullet, player.position, Quaternion.Euler(rotation));
                    break;
                case Consts.PlayerType.Bomber:
                    GameObject g = (GameObject)Instantiate(Bomb, player.position, player.rotation);
                    g.GetComponent<Rigidbody>().AddRelativeForce(BombStrength, ForceMode.Impulse);
                    break;
                case Consts.PlayerType.Knight:
                    meeleRange.enabled = true;
                    break;
                case Consts.PlayerType.Mage:
                    break;
            }
            timer = 0f;
        }

        if (shoot && timer >= Cooldown && PlayerID == Consts.PlayerID.Two)
        {
            switch (Player.Player2Type)
            {
                case Consts.PlayerType.LongShot:
                    muzzleFlash.Play("MuzzleFlash");
                    Vector3 rotation = player.rotation.eulerAngles;
                    rotation.y -= 90f;
                    Instantiate(bullet, player.position, Quaternion.Euler(rotation));
                    break;
                case Consts.PlayerType.Bomber:
                    GameObject g = (GameObject)Instantiate(Bomb, player.position, player.rotation);
                    g.GetComponent<Rigidbody>().AddRelativeForce(BombStrength, ForceMode.Impulse);
                    break;
                case Consts.PlayerType.Knight:
                    meeleRange.enabled = true;
                    break;
                case Consts.PlayerType.Mage:
                    Vector3 magerotation = player.rotation.eulerAngles;
                    magerotation.y -= 90f;
                    Bullet b = Instantiate(bullet, player.position, Quaternion.Euler(magerotation));
                    b.GetComponent<SpriteRenderer>().sprite = Magic;
                    break;
            }
            timer = 0f;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().StartCoroutine(other.gameObject.GetComponent<Enemy>().TakeDamage(meeleDamage));
            meeleRange.enabled = false;
        }

    }
}
