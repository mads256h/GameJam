using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscreen_Camera : MonoBehaviour {

    public GameObject fade, button;


    public void StartGame()
    {
        GetComponent<Animator>().enabled = true;
        button.SetActive(false);
    }

	public void LoadGame()
    {
        SceneManager.LoadScene("main");
    }

    public void StartFade()
    {
        fade.SetActive(true);
    }
}
