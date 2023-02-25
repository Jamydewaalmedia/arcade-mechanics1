using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    

    Rigidbody rb;
    private Transform camTransform;
    private Transform playermodel;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

     camTransform=    transform.GetChild(3);
        playermodel= transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

      //  Debug.Log(camTransform.transform.rotation);
        Vector3 velocity= new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        playermodel.transform.eulerAngles = new Vector3(

        playermodel.transform.eulerAngles.x,
            camTransform.rotation.eulerAngles.y,

        playermodel.transform.eulerAngles.z
            );
        Vector3 rotated = Quaternion.Euler(0, camTransform.transform.rotation.eulerAngles.y, 0) * velocity;
        //Vector3 forwardVel=   transform.forward
       
        rb.velocity = rotated;
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            

            Jump();

            
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
      /*  if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        } */
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}