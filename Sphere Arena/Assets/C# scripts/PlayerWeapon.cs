using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float pushStrength;
    protected Vector3 pushDirection;

    private void Start()
    {
        SetDirection();
    }

    private void OnTriggerStay(Collider other)
    {
        //for testing
        if (Input.GetKey(KeyCode.Space))
            Push(other);
    }

    protected abstract void SetDirection();

    public void Push(Collider ball)
    {
        if (ball.gameObject.tag == "ball")
        {
            ball.gameObject.GetComponent<Rigidbody>().AddForce(pushDirection * pushStrength);
            ball.GetComponent<Sphere>().lastForce = (pushDirection * pushStrength);
        }
    }
}
