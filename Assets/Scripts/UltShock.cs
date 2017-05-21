using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltShock : MonoBehaviour
{

    public float ShockRadius = 64f;

    public int Damage = 10;

    public float TimeStunned = 5f;

    public float TimeActive = 0.5f;

    public new GameObject particleSystem;

    public Vector3 ParticleSystemRotation = Vector3.zero;

    private CapsuleCollider capsuleCollider;


    // Use this for initialization
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.radius = ShockRadius;
        capsuleCollider.enabled = false;
        Explode();
    }



    void Explode()
    {
        capsuleCollider.enabled = true;
        ((GameObject)Instantiate(particleSystem, transform.position, Quaternion.Euler(ParticleSystemRotation))).transform.localScale = new Vector3(1 * 32, 1 * 32, 1 * 32);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().StartCoroutine(other.gameObject.GetComponent<Enemy>().TakeDamage(Damage));
            //other.GetComponent<Enemy>().StartCoroutine(other.gameObject.GetComponent<Enemy>().Stun(TimeStunned));
        }

        Destroy(gameObject);
    }
}
