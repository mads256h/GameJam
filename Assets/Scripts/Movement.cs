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
        Vector2 input = Vector2.zero;

        if(player == 1)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal1"), Input.GetAxisRaw("Vertical1"));
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
        }
            

        transform.Translate(input * speed * Time.deltaTime);
	}
}
