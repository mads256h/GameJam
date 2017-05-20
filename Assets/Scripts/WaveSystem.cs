using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour {

    [Header("Hvor mange enemies er der i hver wave")]
    public int[] enemies;

    [Header("skriv hvilken wave bossen spawner i. bossen blive fundet efter indexet i denne array.")]
    public int[] boss;

    private int waveIndex = -1;

    public static int currentEnemies = 0;
	
	void Update ()
    {
		if(currentEnemies == 0)
        {
            waveIndex++;

            for (int i = 0; i < enemies[waveIndex]; i++)
            {
                //Init enemy
            }

            for (int i = 0; i < boss.Length; i++)
            {
                if(boss[i] == waveIndex)
                {
                    //Spawn boss
                }
            }
        }
	}
}
