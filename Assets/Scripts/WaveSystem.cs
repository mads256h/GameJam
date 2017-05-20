using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour {

    [Header("Hvor mange enemies er der i hver wave")]
    public int[] enemies;

    public GameObject[] diff_enemies;

    [Header("skriv hvilken wave bossen spawner i. bossen blive fundet efter indexet i denne array.")]
    public int[] boss;

    private Transform[] spawningPos;

    private int waveIndex = -1, bossIndex = -1;

    public static int currentEnemies = 0;

    void Start()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Spawning_pos");

        spawningPos = new Transform[g.Length];

        for(int i = 0; i < g.Length; i++)
        {
            spawningPos[i] = g[i].transform;
        }
    }
	
	void Update ()
    {
		if(currentEnemies == 0)
        {
            waveIndex++;

            if (waveIndex > enemies.Length - 1)
                waveIndex = enemies.Length - 1;

            for (int i = 0; i < enemies[waveIndex]; i++)
            {
                GameObject enemy = diff_enemies[Random.Range(0, diff_enemies.Length - 1)];
                Instantiate(enemy, spawningPos[Random.Range(0, spawningPos.Length - 1)].position, Quaternion.identity);
            }

            GameObject[] p = GameObject.FindGameObjectsWithTag("Player");


            for(int i = 0; i < p.Length; i++)
            {
                p[i].GetComponent<Player>().GainHeath(100);
            }

        }
	}
}
