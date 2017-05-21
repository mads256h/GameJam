using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltBomb : MonoBehaviour {

    public float TimeToExplode = 2.5f;

    public int ScatterBombs = 10;

    public float ScatterRadius = 64f;

    public GameObject Bomb;

    public Vector3 BombRotation = Vector3.zero;

    private float timer = 0f;

	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= TimeToExplode)
            Explode();
	}

    void Explode()
    {
        for (int i = 0; i < ScatterBombs; i++)
        {
            Vector2 vector = Random.insideUnitCircle;
            vector.Normalize();
            Vector3 veector = new Vector3(vector.x, 0f, vector.y);
            GameObject g = Instantiate(Bomb, transform.position, Quaternion.Euler(BombRotation));
            g.GetComponent<Rigidbody>().AddForce((veector * ScatterRadius), ForceMode.Impulse);
        }
        Destroy(gameObject);
    }
}
