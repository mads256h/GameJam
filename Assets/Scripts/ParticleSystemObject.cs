﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemObject : MonoBehaviour {
	
	// Update is called once per frame
	void Start () {
        Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().duration);
		
	}
}
