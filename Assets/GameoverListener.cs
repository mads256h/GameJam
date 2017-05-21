using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverListener : MonoBehaviour {

	void Restart()
    {
        Application.LoadLevel(1);
    }

    void Update()
    {
        if (Input.GetButtonDown("A"))
        {
            Restart();
        }
    }
}
