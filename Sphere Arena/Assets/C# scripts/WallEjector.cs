using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEjector : MonoBehaviour
{
    [Tooltip("a multiplier for how strong the wall will eject a ball")]
    [SerializeField] float ejectMultiplier;

    [SerializeField] GameObject impactFlash; //A gameobject that contains particle effects

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ball")
        {
            GameObject ball = collision.collider.gameObject;
            Sphere sphere = ball.GetComponent<Sphere>();
            Vector3 newForce = sphere.lastForce;
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(-newForce.x, newForce.y, newForce.z) * ejectMultiplier);
            sphere.lastForce = newForce;
            GetComponent<AudioSource>().Play();
            GameObject flash = Instantiate(impactFlash, collision.GetContact(0).point, new Quaternion());
            Destroy(flash, 3);
        }
    }
}
