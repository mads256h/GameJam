using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Consts.PlayerType Player1Type = Consts.PlayerType.Mage;
    public static Consts.PlayerType Player2Type = Consts.PlayerType.Bomber;

    public Consts.PlayerID PlayerID; //Om det er spiller 1 eller 2
    public int HeroType; //Hvilken type hero det er Sniper = 1 Bombman = 2 Melee dude = 3 Mage = 4



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

            Updatelifebar();

            isDead = health < 0 ? true : false;

            if (health > 100)
                health = 100;

            if (health < 0)
                health = 0;
        }
    }
    public float Score;

    public float lerpSpeed; //Hvor hurtigt healthbar er "animeret"
    public Image HealthBar; //Healthbar. Skal være sat til filled horizontal.

    public bool isDead;


    void Updatelifebar()
    {
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, Health / 100, Time.deltaTime * lerpSpeed); //"Animere" healthbaren
    }

    public void AddScore (float scoreToAdd) //Tilføj point
    {
        Score += scoreToAdd; 
    } 

    public void TakeDamage (float damageToLose) { //Mist liv
        Health -= damageToLose;

	}

    public void GainHeath (float healthToGain) //Få liv
    {
        isDead = false;
        Health += healthToGain;


    }
}
