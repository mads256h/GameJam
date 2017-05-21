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

    public AudioClip BombSound;

    public float BombVolume = 0.75f;

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
        GameObject.Find("cam1").GetComponentInChildren<Screenshake>().Shake(20);
        GameObject.Find("cam2").GetComponentInChildren<Screenshake>().Shake(20);
        capsuleCollider.enabled = true;
        toRemove = true;
        timer = 0f;
        ((GameObject)Instantiate(particleSystem, transform.position, Quaternion.Euler(ParticleSystemRotation))).transform.localScale = new Vector3(1*32,1*32,1*32);
        AudioManager.PlaySound(transform.position, BombSound, BombVolume);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().StartCoroutine(other.gameObject.GetComponent<Enemy>().TakeDamage(Damage));
        }

        Destroy(gameObject);
    }
}
