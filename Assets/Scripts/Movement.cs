using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //speed = 5 er en passende hastighed.
    public float speed = 5;

    public Consts.PlayerID playerID;

    private Player player;

    public AudioSource footstep;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update ()
    {
        Vector3 input = Vector3.zero;

        if (player.isDead)
            return;


        switch (playerID)
        {
            case Consts.PlayerID.One:
                input = new Vector3(Input.GetAxisRaw("Horizontal1"), 0, Input.GetAxisRaw("Vertical1"));
                break;
            case Consts.PlayerID.Two:
                input = new Vector3(Input.GetAxisRaw("Horizontal2"), 0, Input.GetAxisRaw("Vertical2"));
                break;

        }

        input.Normalize();

        if (input == Vector3.zero)
            footstep.Stop();
        else
        {
            if (!footstep.isPlaying)
                footstep.Play();
        }

        transform.position += (input * speed * Time.deltaTime);
	}
}
