using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float lerpSpeed;

    public GameObject camera, target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 t = new Vector3(target.transform.position.x, camera.transform.position.y, target.transform.position.z);

        camera.transform.position = Vector3.Lerp(camera.transform.position,t, lerpSpeed * Time.deltaTime);
	}
}
