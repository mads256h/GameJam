using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int PlayerID;

    public float Health;
    public float Score;

    public float lerpSpeed;
    public Image HealthBar;

    void Update()
    {
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, Health / 100, Time.deltaTime * lerpSpeed);
    }

    public void AddScore (float scoreToAdd)
    {
        Score = Score + scoreToAdd;
    } 

    public void TakeDamage (float damageToLose) {
        Health = Health - damageToLose;
	}

    public void GainHeath (float healthToGain)
    {
        Health = Health + healthToGain;
    }
}
