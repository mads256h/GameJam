using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour {

    public string Tag = "Player";
    public float FadeOutAlpha = 0.1f;

    private new SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == Tag)
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, FadeOutAlpha);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tag)
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
    }
}
