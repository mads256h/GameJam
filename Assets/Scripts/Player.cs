using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Consts.PlayerType Player1Type = Consts.PlayerType.Mage;
    public static Consts.PlayerType Player2Type = Consts.PlayerType.Bomber;

    public Consts.PlayerID PlayerID; //Om det er spiller 1 eller 2
    public int HeroType; //Hvilken type hero det er Sniper = 1 Bombman = 2 Melee dude = 3 Mage = 4

    float powerupTimer, oldFireRate;

    Consts.PowerUpType put;

    bool havePowerup;

    public float health;


    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;

            isDead = health < 0 ? true : false;

            if (health > 100)
                health = 100;

            if (health < 0)
                health = 0;

            if(GameObject.Find("PlayerOne").GetComponent<Player>().health == 0 && GameObject.Find("PlayerTwo").GetComponent<Player>().health == 0)
            {
                GameObject.Find("Game manager").GetComponent<GameManager>().GameOver();
            }
        }
    }
    private void Update()
    {
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, Health / 100, Time.deltaTime * lerpSpeed); //"Animere" healthbaren
        transform.name = "Player" + PlayerID;
    }

    public float Score;

    public float lerpSpeed; //Hvor hurtigt healthbar er "animeret"
    public Image HealthBar; //Healthbar. Skal være sat til filled horizontal.

    public bool isDead;


    public void AddScore (float scoreToAdd) //Tilføj point
    {
        Score += scoreToAdd; 
    } 

    public void TakeDamage (float damageToLose) { //Mist liv
        Health -= damageToLose;
        if(PlayerID == Consts.PlayerID.One)
        {
            GameObject.Find("cam1").GetComponentInChildren<BloodEffect>().BloodAndShake();
        }
        if (PlayerID == Consts.PlayerID.Two)
        {
            GameObject.Find("cam2").GetComponentInChildren<BloodEffect>().BloodAndShake();
        }
    }

    public void GainHeath (float healthToGain) //Få liv
    {
        isDead = false;
        Health += healthToGain;


    }

    void OnTriggerEnter(Collider o)
    {
        if(o.tag == "powerup" && !havePowerup)
        {

            put = o.GetComponent<PowerUp>().PowerUpType;

            if (o.GetComponent<PowerUp>().PowerUpType == Consts.PowerUpType.Blast)
            {
                GameObject g = Resources.Load("bomb") as GameObject;
            }

            if (o.GetComponent<PowerUp>().PowerUpType == Consts.PowerUpType.Firerate)
            {
                oldFireRate = GetComponent<WeaponScript>().Cooldown;
                havePowerup = true;
                GetComponent<WeaponScript>().Cooldown = 0.1f;
                StartCoroutine(DisableFirerate());
            }

            if (o.GetComponent<PowerUp>().PowerUpType == Consts.PowerUpType.Health)
            {
                GainHeath(100);
            }

            if (o.GetComponent<PowerUp>().PowerUpType == Consts.PowerUpType.Oneshot)
            {
                havePowerup = true;
                GetComponent<WeaponScript>().damange *= 100;
                StartCoroutine(DisableOneshot());
            }

            
            
            Destroy(o.gameObject);
        }
    }

    IEnumerator DisableOneshot()
    {
        Debug.Log("asjkldasjd");
        yield return new WaitForSeconds(8);
        Debug.Log("ajkkkkk");

        GetComponent<WeaponScript>().damange /= 100;

        havePowerup = false;

        yield return new WaitForSeconds(8);
        Debug.Log("yyyyyyyyyyyyyyyyyyyyy");

    }

    IEnumerator DisableFirerate()
    {
        Debug.Log("jjjjjjjjjjjjjjjjjjjjjjjjjj");
        yield return new WaitForSeconds(8);
        Debug.Log("hhhhhhhhhhhhhhhhhhhhhhhhh");
        GetComponent<WeaponScript>().Cooldown = oldFireRate;

        havePowerup = false;

        yield return new WaitForSeconds(8);
        Debug.Log("ååååååååååååååååå");
    }
}
