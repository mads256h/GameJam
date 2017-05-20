using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Consts.PlayerID PlayerID = Consts.PlayerID.One;

    public Bullet bullet;

    public GameObject Bomb;

    public Vector3 BombStrength = new Vector3(0, 0, 1f);

    public Animator muzzleFlash;

    public Transform player;

    private Player playerScript;

    public float Cooldown = 0.5f;

    private float timer = 0f;

    public bool testGun;

    void Start()
    {
        player = GetComponent<Transform>();
        playerScript = GetComponent<Player>();
    }

    void Update ()
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
                    ((GameObject)Instantiate(Bomb, player.position, player.rotation)).GetComponent<Rigidbody>().AddForce(BombStrength, ForceMode.Impulse);
                    break;
                case Consts.PlayerType.Knight:
                    break;
                case Consts.PlayerType.Mage:
                    break;
            }
            timer = 0f;
        }
	}
}
