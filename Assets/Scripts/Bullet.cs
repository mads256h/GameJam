using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 10f;

    public float TimeToLive = 2f;

    public float IgnoreTime = 0.5f;

    private float timer = 0.0f;

    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Speed * Time.deltaTime, 0f, 0f));
        timer += Time.deltaTime;
        if (timer >= IgnoreTime)
            boxCollider.enabled = true;

        if (timer >= TimeToLive)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.GetComponent<Enemy>())
        {

            Destroy(gameObject);
        }
    }
}