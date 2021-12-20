using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugPlayerMovement : MonoBehaviour
{
    [SerializeField] float speedLimiter;
    Rigidbody rb;
    [HideInInspector] public PlayerWeapon activeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") / speedLimiter, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Sphere>() && activeWeapon != null)
            activeWeapon.Push(collision.collider);
    }
}
