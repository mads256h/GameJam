using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

    /// <summary>
    /// Script til styring af particlesystems
    /// 
    /// Brug SetDuration til at sætte hvor lang tid systemet spiller
    /// 
    /// 
    /// </summary>


    private ParticleSystem PS;
    private ParticleSystem.MainModule PSMA;

	void Start ()
    {
        PS = GetComponentInChildren<ParticleSystem>();
        PSMA = PS.main;
	}
	

	void Update ()
    {
		
	}

    void SetDuration(int Duration)
    {
        PSMA.duration = Duration;
    }

}
