using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugPlayerMovement : MonoBehaviour
{
    [SerializeField] float speedLimiter;
    Rigidbody rb;
    [HideInInspector] public PlayerWeapon activeWeapon;

    Vector3 movementPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move pawns with keyboard buttons
        //movementPosition = new Vector3(transform.position.x + Input.GetAxis("Horizontal") / speedLimiter, transform.position.y, transform.position.z);

        //move pawns using phone tilt
        movementPosition = new Vector3(transform.position.x + Input.acceleration.x / speedLimiter, transform.position.y, transform.position.z);

        rb.MovePosition(movementPosition);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Sphere>() && activeWeapon != null)
            activeWeapon.Push(collision.collider);
    }
}
