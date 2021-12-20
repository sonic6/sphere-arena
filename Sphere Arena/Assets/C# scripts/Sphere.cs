using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [HideInInspector] public GameObject lastCollider;
    public Vector3 lastForce;
    bool firstCollision = true;
    [SerializeField] GameObject shockwavePrefab;
    [SerializeField] float speed;
    int random;
    [SerializeField] List<ParticleSystem> hitParticles;
    [SerializeField] AudioClip hitSound;

    private void Start()
    {
        random = (Random.Range(0, 2) * 2) - 1; //Either 1 or -1
        GetComponent<SphereCollider>().attachedRigidbody.AddForce(random * lastForce * speed);
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayFirstCollision(collision.GetContact(0).point);
        HitOtherSphere(collision);
    }

    void HitOtherSphere(Collision other)
    {
        if(other.gameObject.GetComponent<Sphere>())
        {
            GameObject ball = other.collider.gameObject;
            Sphere sphere = ball.GetComponent<Sphere>();
            Vector3 newForce = sphere.lastForce;
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(-newForce.x, newForce.y, newForce.z) * -1);
            sphere.lastForce = newForce;

            foreach (ParticleSystem system in hitParticles)
                system.Play();
            
            GetComponent<AudioSource>().clip = hitSound;
            GetComponent<AudioSource>().Play();
        }
    }

    //Plays visual effect when the sphere hits the ground for the first time after spawning in
    void PlayFirstCollision(Vector3 point)
    {
        if (firstCollision)
        {
            GameObject wave = Instantiate(shockwavePrefab, point, new Quaternion());
            wave.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(wave, 3);
        }
        firstCollision = false;
    }
}
