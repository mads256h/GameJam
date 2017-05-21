using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour {

    public Text waveText;

    public int wave;

    public Text infoText;

    [Header("Hvor mange enemies er der i hver wave")]
    public int[] enemies;

    public GameObject[] diff_enemies;

    private Transform[] spawningPos;

    private int waveIndex = -1;

    public static int currentEnemies = 0;

    bool midWave;

    void Start()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Spawning_pos");

        spawningPos = new Transform[g.Length];

        for(int i = 0; i < g.Length; i++)
        {
            spawningPos[i] = g[i].transform;
        }

        midWave = false;

        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
	
	void Update ()
    {
		if(currentEnemies == 0 && !midWave)
        {
            StartCoroutine(SpawnWave());
        }
	}

    IEnumerator SpawnWave ()
    {
        wave = wave + 1;
        waveText.text = "Wave: " + wave.ToString();

        midWave = true;
        for(int i = 5; i > -1; i--)
        {
            yield return new WaitForSeconds(1);
            infoText.text = "Next wave: " + i + " sec!";
        }
        infoText.text = "Playing wave  " + wave;

        waveIndex++;

        if (waveIndex > enemies.Length - 1)
            waveIndex = enemies.Length - 1;

        for (int i = 0; i < enemies[waveIndex]; i++)
        {

            int diff = Random.Range(0, 100);

            if(diff < 80)
            {
                GameObject e = diff_enemies[1];
                Instantiate(e, spawningPos[Random.Range(0, spawningPos.Length - 1)].position, Quaternion.identity);
            }
            else
            {
                GameObject enemy = diff_enemies[Random.Range(0, diff_enemies.Length - 1)];
                Instantiate(enemy, spawningPos[Random.Range(0, spawningPos.Length - 1)].position, Quaternion.identity);
            }

            
        }

        GameObject[] p = GameObject.FindGameObjectsWithTag("Player");


        for (int i = 0; i < p.Length; i++)
        {
            p[i].GetComponent<Player>().GainHeath(100);
        }
        midWave = false;

    }
}
