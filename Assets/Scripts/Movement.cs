using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //speed = 5 er en passende hastighed.
    public float speed = 5;

    [Range(1,2)]
    public int player = 1;


	void Update ()
    {
        Vector3 input = Vector3.zero;

        if(player == 1)
        {
            input = new Vector3(Input.GetAxisRaw("Horizontal1"), 0, Input.GetAxisRaw("Vertical1"));
        }
        else
        {
            input = new Vector3(Input.GetAxisRaw("Horizontal2"),0, Input.GetAxisRaw("Vertical2"));
        }


        input.Normalize();

        transform.position += (input * speed * Time.deltaTime);
	}
}
