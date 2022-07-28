using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Sphere : MonoBehaviourPunCallbacks/*, IPunObservable*/
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


    private void OnCollisionEnter(Collision collision)
    {
        PlayFirstCollision(collision.GetContact(0).point);
        HitOtherSphere(collision);
    }

    void HitOtherSphere(Collision other)
    {
        if(other.gameObject.GetComponent<Sphere>())
        {
            OrganizeSphereMovement(other);
            PlayParticlesAndSounds();
        }
    }

    //If this instance of the game is being played by the network master, then it's allowed to dictate the sphere's movement
    void OrganizeSphereMovement(Collision other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject ball = other.collider.gameObject;
            Sphere sphere = ball.GetComponent<Sphere>();
            Vector3 newForce = sphere.lastForce;
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(-newForce.x, newForce.y, newForce.z) * -1);
            sphere.lastForce = newForce;
        }
    }

    void PlayParticlesAndSounds()
    {
        foreach (ParticleSystem system in hitParticles)
            system.Play();

        GetComponent<AudioSource>().clip = hitSound;
        GetComponent<AudioSource>().Play();
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

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //        stream.SendNext(transform.position);
    //    else
    //        transform.position = (Vector3)stream.ReceiveNext();
    //}
}
