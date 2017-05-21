using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float lerpSpeed;

    public GameObject camera, target;

    Vector3 offset;

    static bool shake;

	// Use this for initialization
	void Start ()
    {
		
	}

    public static void CameraShake(bool active = true)
    {
        shake = active;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 t = new Vector3(target.transform.position.x, camera.transform.position.y, target.transform.position.z);

        if(shake)
        {
            offset = new Vector3(Random.Range(1, 4), 0, Random.Range(1, 4));

            offset += t;
        }

        camera.transform.position = Vector3.Lerp(camera.transform.position,t, lerpSpeed * Time.deltaTime);
	}
}
