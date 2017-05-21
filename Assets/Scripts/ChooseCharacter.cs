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
        PlayerID = Consts.PlayerID.Two;

    }

    public void PressLongShot()
    {
        ButtonLongShot.interactable = false;
        if (PlayerID == Consts.PlayerID.One)
        {
            Player2();
            Player.Player1Type = Consts.PlayerType.LongShot;
            ButtonBomber.Select();
        }
        else
        {
            Player.Player2Type = Consts.PlayerType.LongShot;
        }

    }

    public void PressBomber()
    {
        ButtonBomber.interactable = false;
        if (PlayerID == Consts.PlayerID.One)
        {
            Player2();
            Player.Player1Type = Consts.PlayerType.Bomber;
            ButtonLongShot.Select();
        }
        else
        {
            Player.Player2Type = Consts.PlayerType.Bomber;
        }
    }

    public void PressKnight()
    {
        ButtonKnight.interactable = false;
        if (PlayerID == Consts.PlayerID.One)
        {
            Player2();
            Player.Player1Type = Consts.PlayerType.Knight;
            ButtonLongShot.Select();
        }
        else
        {
            Player.Player2Type = Consts.PlayerType.Knight;
        }
    }

    public void PressMage()
    {
        ButtonMage.interactable = false;
        if (PlayerID == Consts.PlayerID.One)
        {
            Player2();
            Player.Player1Type = Consts.PlayerType.Mage;
            ButtonLongShot.Select();
        }
        else
        {
            Player.Player2Type = Consts.PlayerType.Mage;
        }
    }
}