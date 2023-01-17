using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;

public class DebugPlayerMovement : MonoBehaviour
{
    bool keyboardInput = true;

    [SerializeField] float speedLimiter;
    Rigidbody rb;
    [HideInInspector] public PlayerWeapon activeWeapon;

    Vector3 movementPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //If this gameobject is not the player for this device, disable its player controller
        if (PhotonRoom.localPlayerID != GetComponent<PhotonView>().ViewID)
        {
            enabled = false;
            print("local player ID is " + PhotonRoom.localPlayerID);
            print(gameObject.name + "'s ViewID is " + GetComponent<PhotonView>().ViewID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move pawns with keyboard buttons
        if(keyboardInput)
            movementPosition = new Vector3(transform.position.x + Input.GetAxis("Horizontal") / speedLimiter, transform.position.y, transform.position.z);

        //move pawns using phone tilt
        else
            movementPosition = new Vector3(transform.position.x + Input.acceleration.x / speedLimiter, transform.position.y, transform.position.z);

        rb.MovePosition(movementPosition);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Sphere>() && activeWeapon != null)
            activeWeapon.Push(collision.collider);
    }
}
