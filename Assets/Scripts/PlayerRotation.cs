using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    
    public Consts.PlayerID PlayerID = Consts.PlayerID.One;

    public float correctionAngle = 0;

    private new Transform transform;


	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        float angle = 0;

        switch (PlayerID)
        {
            case Consts.PlayerID.One:
                angle = Mathf.Atan2(Input.GetAxis("RotVertical1"), Input.GetAxis("RotHorizontal1")) * Mathf.Rad2Deg;
                break;

            case Consts.PlayerID.Two:
                angle = Mathf.Atan2(Input.GetAxis("RotVertical2"), Input.GetAxis("RotHorizontal2")) * Mathf.Rad2Deg;
                break;
        }
        if (angle == 0f) //If angle is zero there is no need to update
            return;

        transform.rotation = Quaternion.Euler(90f, angle + correctionAngle, 0f);

	}
}
