using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ult_mage : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        GameObject[] g = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(g.Length);

        for(int i = 0; i < g.Length; i++)
        {
            if(Vector3.Distance(transform.position,g[i].transform.position) <= 10)
            {
                g[i].GetComponent<Enemy>().StunnedFor += 5;
            }
        }

        Destroy(gameObject, 5);	
	}
	
    void OnDestroy()
    {

    }
}
