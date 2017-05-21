using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public GameObject gameOver;
    public Text goscore;
    public Text gohighScore;
    public Text goWaves;
    public Text goHighscoreWaves;
    public GameObject newHS;
    public GameObject newWaveHS;

    public float Score;
    float LerpedScore;
    float lerpedScore;
    public Text ScoreText;
    public HeroClass[] heros;

    public GameObject cam1, cam2;

    public Image healthbar1, healthbar2;

    private void Update()
    {
        LerpedScore = Mathf.Lerp(LerpedScore, Score, Time.deltaTime * 8);
        ScoreText.text = "Score: " + LerpedScore.ToString("F0");
    }

    public void GameOver ()
    {
        gameOver.SetActive(true);

        if (Score > PlayerPrefs.GetFloat("ScoreHS"))
        {
            newHS.SetActive(true);
            PlayerPrefs.SetFloat("ScoreHS", Score);
        }
        if (GetComponent<WaveSystem>().wave > PlayerPrefs.GetFloat("WaveHS"))
        {
            newWaveHS.SetActive(true);
            PlayerPrefs.SetFloat("WaveHS", GetComponent<WaveSystem>().wave);
        }

        goscore.text = "Score: " + Score;
        gohighScore.text = "Highscore: " + PlayerPrefs.GetFloat("ScoreHS").ToString();

        goWaves.text = "Score: " + GetComponent<WaveSystem>().wave;
        gohighScore.text = "Highscore: " + PlayerPrefs.GetFloat("WaveHS").ToString();
        RestartCheck();
    }

    void RestartCheck()
    {
        StartCoroutine(restartGame());
    }

    IEnumerator restartGame()
    {
        if (Input.GetButtonDown("A"))
        {
            Application.LoadLevel(1);
        }
        yield return null;
        StartCoroutine(restartGame());
    }

    void Start()
    {
        for(int i = 0; i < heros.Length; i++)
        {
            if(Player.Player1Type == heros[i].type)
            {
                GameObject g = (GameObject) Instantiate(heros[i].obj, new Vector3(276.0555f,0, 230.8f), heros[i].obj.transform.rotation);
                g.GetComponent<CameraScript>().camera = cam1;
                g.GetComponent<Player>().HealthBar = healthbar1;
            }

            if (Player.Player2Type == heros[i].type)
            {


                GameObject g = (GameObject)Instantiate(heros[i].obj, new Vector3(276.0555f, 0, 297.2f), heros[i].obj.transform.rotation);

                g.GetComponent<Movement>().playerID = Consts.PlayerID.Two;
                g.GetComponent<PlayerRotation>().PlayerID = Consts.PlayerID.Two;
                g.GetComponent<WeaponScript>().PlayerID = Consts.PlayerID.Two;
                g.GetComponent<Player>().PlayerID = Consts.PlayerID.Two;

                g.GetComponent<Player>().HealthBar = healthbar2;

                g.GetComponent<CameraScript>().camera = cam2;
            }
        }
    }
    
}
