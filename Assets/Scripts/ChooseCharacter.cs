using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChooseCharacter : MonoBehaviour
{

    public Text PlayerIndicator;
    public Button ButtonLongShot;
    public Button ButtonBomber;
    public Button ButtonKnight;
    public Button ButtonMage;

    public StandaloneInputModule InputModule;

    private Consts.PlayerID PlayerID = Consts.PlayerID.One;


    // Use this for initialization
    void Start()
    {
        PlayerIndicator.text = "Player 1";
        InputModule.horizontalAxis = "Horizontal1";
        InputModule.verticalAxis = "Vertical1";
        InputModule.submitButton = "Submit1";
    }

    void Player2()
    {
        PlayerIndicator.text = "Player 2";
        InputModule.horizontalAxis = "Horizontal2";
        InputModule.verticalAxis = "Vertical2";
        InputModule.submitButton = "Submit2";

    }

    void PressLongShot()
    {
        ButtonLongShot.enabled = false;
        if (PlayerID == Consts.PlayerID.One)
        {
            
        }

    }

    void PressBomber()
    {

    }

    void PressKnight()
    {

    }

    void PressMage()
    {

    }
}