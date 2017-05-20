using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour {

    [Header("Hvor mange enemies er der i hver wave")]
    public int[] enemies;

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

            GameObject enemy = Resources.Load("enemy") as GameObject;

            for (int i = 0; i < enemies[waveIndex]; i++)
            {
                Instantiate(enemy, spawningPos[Random.Range(0, spawningPos.Length - 1)].position, Quaternion.identity);
            }

            /*
            for (int i = 0; i < boss.Length; i++)
            {
                if(boss[i] == waveIndex)
                {
                    bossIndex++;

                    if (bossIndex > 2)
                        bossIndex = 2;

                    Instantiate(GetComponent<GameManager>().bosses[bossIndex].obj,spawningPos[Random.Range(0,spawningPos.Length-1)].position,Quaternion.identity);
                }
            }

    */
        }
	}
}
