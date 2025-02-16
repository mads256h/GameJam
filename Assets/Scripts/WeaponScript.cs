﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public Consts.PlayerID PlayerID = Consts.PlayerID.One;

    public Bullet bullet;

    public AudioClip bulletSound;

    public float bulletVolume = 0.75f;

    public GameObject Bomb;

    public Vector3 BombStrength = new Vector3(0, 0, 1f);

    public CapsuleCollider meleeRange;

    public int meeleDamage = 50;

    public int damange;

    public AudioClip meleeSound;

    public float meleeVolume = 0.75f;

    public Animator muzzleFlash;

    public Transform player;

    private Player playerScript;

    public float Cooldown = 0.5f;

    private float timer = 0f;

    public AudioClip clip;

    public GameObject ult;

    private float ult_timer, ult_cooldown = 15;

    void Start()
    {
        player = GetComponent<Transform>();
        playerScript = GetComponent<Player>();
        ult_timer = ult_cooldown;


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
            if(Player.Player1Type != Consts.PlayerType.Bomber)
            GameObject.Find("cam1").GetComponentInChildren<Screenshake>().Shake();
            switch (Player.Player1Type)
            {
                case Consts.PlayerType.LongShot:
                    muzzleFlash.Play("MuzzleFlash");
                    Vector3 rotation = player.rotation.eulerAngles;
                    AudioManager.PlaySound(transform.position, clip);
                    rotation.y -= 90f;
                    Bullet bu = Instantiate(bullet, player.position, Quaternion.Euler(rotation)) as Bullet;
                    bu.damage = damange;
                    AudioManager.PlaySound(transform.position, bulletSound, bulletVolume);
                    break;
                case Consts.PlayerType.Bomber:
                    GameObject g = (GameObject)Instantiate(Bomb, player.position, player.rotation);
                    g.GetComponent<Rigidbody>().AddRelativeForce(BombStrength, ForceMode.Impulse);
                    break;
                case Consts.PlayerType.Knight:
                    meleeRange.enabled = true;
                    AudioManager.PlaySound(transform.position, meleeSound, meleeVolume);
                    break;
                case Consts.PlayerType.Mage:
                    Vector3 magerotation = player.rotation.eulerAngles;
                    magerotation.y -= 90f;
                    Bullet b = Instantiate(bullet, new Vector3(player.position.x, 11, player.position.z), Quaternion.Euler(magerotation));
                    b.damage = damange;
                    AudioManager.PlaySound(transform.position, clip);
                    break;
            }
            timer = 0f;
        }

        if (shoot && timer >= Cooldown && PlayerID == Consts.PlayerID.Two)
        {
            if (Player.Player2Type != Consts.PlayerType.Bomber)
                GameObject.Find("cam2").GetComponentInChildren<Screenshake>().Shake();
            switch (Player.Player2Type)
            {
                case Consts.PlayerType.LongShot:
                    muzzleFlash.Play("MuzzleFlash");
                    Vector3 rotation = player.rotation.eulerAngles;
                    rotation.y -= 90f;
                    Instantiate(bullet, player.position, Quaternion.Euler(rotation));
                    AudioManager.PlaySound(transform.position, bulletSound, bulletVolume);
                    break;
                case Consts.PlayerType.Bomber:
                    GameObject g = (GameObject)Instantiate(Bomb, player.position, player.rotation);
                    g.GetComponent<Rigidbody>().AddRelativeForce(BombStrength, ForceMode.Impulse);
                    break;
                case Consts.PlayerType.Knight:
                    meleeRange.enabled = true;
                    AudioManager.PlaySound(transform.position, meleeSound, meleeVolume);
                    break;
                case Consts.PlayerType.Mage:
                    Vector3 magerotation = player.rotation.eulerAngles;
                    magerotation.y -= 90f;
                    Bullet b = Instantiate(bullet, player.position, Quaternion.Euler(magerotation));
                    break;
            }
            timer = 0f;
        }

        ult_timer += Time.deltaTime;
        if(ult_timer >= ult_cooldown)
        {
            if(Input.GetButtonDown("JUlt1") && playerScript.PlayerID == Consts.PlayerID.One)
            {
                ult_timer = 0;

                switch (Player.Player1Type)
                {
                    case Consts.PlayerType.LongShot:
                        muzzleFlash.Play("MuzzleFlash");
                        Vector3 rotation = player.rotation.eulerAngles;
                        rotation.y -= 90f;
                        Instantiate(bullet, player.position, Quaternion.Euler(rotation)).GetComponent<Bullet>().IsUlt = true;
                        AudioManager.PlaySound(transform.position, bulletSound, bulletVolume);
                        break;
                    case Consts.PlayerType.Bomber:
                        break;
                    case Consts.PlayerType.Knight:
                        break;
                    case Consts.PlayerType.Mage:
                        break;
                    default:
                        break;
                }
            }
            else if(Input.GetButtonDown("JUlt2") && playerScript.PlayerID == Consts.PlayerID.Two )
            {
                ult_timer = 0;

                Instantiate(ult, transform.position, ult.transform.rotation);
            }
            
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //other.gameObject.GetComponent<Enemy>().StartCoroutine(other.gameObject.GetComponent<Enemy>().TakeDamage(meeleDamage));

            if(meleeRange != null)
                meleeRange.enabled = false;
        }

    }
}
