using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] float powerupvalue;
    [SerializeField] Rigidbody rb;               // De rigidbody van de speler
    [SerializeField] AudioSource deathSound;     // Het geluid dat afgespeeld wordt als de speler sterft
    [SerializeField]  AudioSource powerdownsound;
    [SerializeField] float jumpforce = 4f;        // De kracht van de sprong
    bool dead = false;                           // Een boolean om bij te houden of de speler al gestorven is

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {

    }

    // Wordt aangeroepen als de speler in aanraking komt met een ander object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))     // Als de speler tegen het lichaam van een vijand botst
        {
            GetComponent<MeshRenderer>().enabled = false;             // Verberg de mesh van de speler
            GetComponent<Rigidbody>().isKinematic = true;             // Maak de rigidbody van de speler kinematisch zodat deze niet meer beweegt
            GetComponent<PlayerMovement>().enabled = false;            // Schakel de beweging van de speler uit
            Die(); // Roep de Die() functie aan
            Debug.Log("enemybody");
        }
        if (collision.gameObject.CompareTag("fallcheck"))    // Als de speler valt
        {
            GetComponent<MeshRenderer>().enabled = false;             // Verberg de mesh van de speler
            GetComponent<Rigidbody>().isKinematic = true;             // Maak de rigidbody van de speler kinematisch zodat deze niet meer beweegt
            GetComponent<PlayerMovement>().enabled = false;            // Schakel de beweging van de speler uit
            Die();                                                      // Roep de Die() functie aan
        }
        if (collision.gameObject.CompareTag("Bounceplatform"))    // Als de speler tegen een stuiterplatform botst
        {
            rb.velocity = new Vector2(0, 10);                          // Geef de speler een opwaartse snelheid
        }
        if (collision.gameObject.CompareTag("PowerUp"))    // Als de speler tegen een PowerUp botst
        {
            
            Destroy(collision.transform.parent.gameObject); // Vernietig het spelobject 
            rb.velocity = new Vector2(0, powerupvalue);                          // Geef de speler een opwaartse snelheid
        }
        if (collision.gameObject.CompareTag("PowerDown"))    // Als de speler tegen een PowerUp botst
        {
            powerdownsound.Play();
            Destroy(collision.transform.parent.gameObject); // Vernietig het spelobject 
            rb.velocity = new Vector2(0, -powerupvalue);                          // Geef de speler een opwaartse snelheid
        }
        if (collision.gameObject.CompareTag("Enemy Head"))     // Als de speler tegen het hoofd van een vijand botst
        {
            Destroy(collision.transform.parent.gameObject);        // Vernietig het spelobject waar het hoofd van de vijand aan vastzit
            jump();                                                 // Laat de speler springen
        }
    }

    // Laat de speler springen
    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpforce, rb.velocity.z);

    }

    // Laat de speler sterven
    void Die()
    {
        Invoke(nameof(reloadlevel), 1.3f);                          // Laad het level opnieuw na een vertraging van 1,3 seconden
        dead = true;                                                // Zet de boolean dead op true
        // deathSound.Play();                                      // Speel het sterf geluid af
    }

    // Laadt het huidige level opnieuw
    void reloadlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
