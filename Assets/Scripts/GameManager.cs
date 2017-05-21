using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public HeroClass[] heros;

    public GameObject cam1, cam2;

    public Image healthbar1, healthbar2;


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
