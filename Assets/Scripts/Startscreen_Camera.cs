using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscreen_Camera : MonoBehaviour {

    public GameObject fade;

	public void LoadGame()
    {
        SceneManager.LoadSceneAsync("main");
    }

    public void StartFade()
    {
        fade.SetActive(true);
    }
}
