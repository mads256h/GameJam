using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscreen_Camera : MonoBehaviour {

    public GameObject fade, button;


    public void StartGame()
    {
        GetComponent<Animator>().enabled = true;
        button.GetComponent<Animator>().Play("Exit");
    }

	public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartFade()
    {
        fade.SetActive(true);
    }
}
