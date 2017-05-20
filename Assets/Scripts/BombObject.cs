using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{

    public float SecToExplode = 2.5f;

    public float ExplodeRadius = 64f;

    public int Damage = 75;

    public float TimeActive = 0.5f;

    public new GameObject particleSystem;

    public Vector3 ParticleSystemRotation = Vector3.zero;

    private CapsuleCollider capsuleCollider;

    private float timer = 0f;

    private bool toRemove = false;

    // Use this for initialization
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.radius = ExplodeRadius;
        capsuleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SecToExplode)
            Explode();
        if (timer >= TimeActive && toRemove)
            Destroy(gameObject);
    }

    void Explode()
    {
        capsuleCollider.enabled = true;
        toRemove = true;
        timer = 0f;
        ((GameObject)Instantiate(particleSystem, transform.position, Quaternion.Euler(ParticleSystemRotation))).transform.localScale = new Vector3(1*32,1*32,1*32);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
        }
    }
}
