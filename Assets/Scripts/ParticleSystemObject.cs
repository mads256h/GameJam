using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemObject : MonoBehaviour {
	
	void Start () {
        Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().main.duration);
		
	}
}
