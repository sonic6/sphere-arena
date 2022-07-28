using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeapon : MonoBehaviour
{
    protected Vector3 pushDirection;
    public static AudioClip weaponNoise;
    public static float pushStrength;
    int directionMultiplier;
    

    private void Start()
    {
        switch(transform.parent.tag)
        {
            case "PlayerOne":
                directionMultiplier = -1;
                break;
            case "PlayerTwo":
                directionMultiplier = 1;
                break;
        }
        SetDirection(directionMultiplier);
        transform.parent.GetComponent<AudioSource>().clip = weaponNoise;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Sphere>())
            GetComponentInParent<DebugPlayerMovement>().activeWeapon = this;

    }

    protected abstract void SetDirection(int directionMultiplier);

    public void Push(Collider ball)
    {
        if (ball.gameObject.tag == "ball")
        {
            transform.parent.GetComponent<AudioSource>().Play();
            ball.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection * pushStrength);
            ball.GetComponent<Sphere>().lastForce = (pushDirection * pushStrength);
        }
    }
}
