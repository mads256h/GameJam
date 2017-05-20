using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour {

    Player player; //Refernce til player scriptet som holder styr på liv id type og score.

	void Start () {
        player = GetComponent<Player>();	
	}
	
	void Update () {
		if(Input.GetButtonDown("Ultimate" + player.PlayerID.ToString())) //Checker om spilleren aktivere ultimate, og hvem der aktivere det.
        {
            ActivateUltimate();
        }
	}
    void ActivateUltimate () //Aktivere ult og checker hvilken type spilleren er.
    {
    }

    void UltLongShot()
    {

    }

    void UltBomber()
    {

    }

    void UltKnight()
    {

    }

    void UltMage()
    {

    }
}
