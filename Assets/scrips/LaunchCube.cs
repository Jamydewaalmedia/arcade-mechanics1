using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCube : MonoBehaviour
{
    Rigidbody myrigidbody;
    [SerializeField] float jumpForce = 80f;
    [SerializeField] float movementSpeed = 6f;
    

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        myrigidbody.velocity = new Vector3(horizontalInput * movementSpeed, myrigidbody.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButton("Jump"))
        {

            myrigidbody.AddForce(transform.up * jumpForce);
        }
    }
}
