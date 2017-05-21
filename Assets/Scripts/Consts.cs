using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consts : MonoBehaviour
{

    public enum PlayerID
    {
        One = 1,
        Two = 2,
    }

    public enum EnemyType
    {
        Slime,
        
    }

    public enum PlayerType
    {
        LongShot,
        Bomber,
        Knight,
        Mage,
    }

    public enum PowerUpType
    {
        Health,
        Oneshot,
        Firerate,
        Blast,
    }
}
