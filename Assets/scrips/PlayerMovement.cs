using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    // Het rigidbody component van het GameObject
    Rigidbody rb;
    // De Transform component van de camera
    private Transform camTransform;
    // De Transform component van het speler model
    private Transform playermodel;
    // De bewegingssnelheid van de speler
    [SerializeField] float movementSpeed = 6f;
    // De kracht waarmee de speler kan springen
    [SerializeField] float jumpForce = 5f;
    // De Transform component van een object dat zich op de grond bevindt
    [SerializeField] Transform groundCheck;
    // De layer waarop de grond zich bevindt
    [SerializeField] LayerMask ground;
    // Het AudioSource component voor het afspelen van het springgeluid
    [SerializeField] AudioSource jumpSound;

    // Start wordt aangeroepen voor de eerste frame updated
    void Start()
    {
        // Haal het rigidbody component op
        rb = GetComponent<Rigidbody>();

        // Haal de Transform componenten van de camera en het speler model op
        camTransform = transform.GetChild(3);
        playermodel = transform.GetChild(0);
    }

    // Update wordt elke frame aangeroepen
    void Update()
    {
        // Haal de horizontale en verticale input op
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Bereken de nieuwe snelheid van de speler
        Vector3 velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        // Pas de rotatie van het speler model aan zodat deze in dezelfde richting kijkt als de camera
        playermodel.transform.eulerAngles = new Vector3(
            playermodel.transform.eulerAngles.x,
            camTransform.rotation.eulerAngles.y,
            playermodel.transform.eulerAngles.z
        );

        // Roteer de snelheidsvector zodat deze in de juiste richting wijst
        Vector3 rotated = Quaternion.Euler(0, camTransform.transform.rotation.eulerAngles.y, 0) * velocity;

        // Pas de snelheid van de speler aan
        rb.velocity = rotated;

        // Als de speler op de grond staat en de jump knop wordt ingedrukt, spring dan
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    // Springfunctie voor de speler
    void Jump()
    {
        // Verander de verticale snelheid van de speler
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        // Speel het jump geluid af
        //jumpSound.Play();
    }

    // Wordt aangeroepen wanneer de speler een ander object raakt
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            // Vernietig het parent GameObject van het object waarmee de speler botst
            Destroy(collision.transform.parent.gameObject);
            // Spring
            Jump();
        }
        */
    }

    // Controleer of de speler zich op de grond bevindt
    bool IsGrounded()
    {
        // Controleer of er een object met de juiste layermask in de buurt is van groundCheck
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
