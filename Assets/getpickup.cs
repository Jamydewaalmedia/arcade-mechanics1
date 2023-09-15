using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getpickup : MonoBehaviour
{
    [SerializeField] Rigidbody rb; // The player's rigidbody
    private testles4 scoreScript; // The script that keeps track of the player's score
    [SerializeField] ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player's rigidbody component
        rb = GetComponent<Rigidbody>();
        // Find the script that keeps track of the player's score
        scoreScript = FindObjectOfType<testles4>();
    }

    // Update is called once per frame
    void Update()
    {
        
        ps = GetComponent<ParticleSystem>();
    }

    // This method is called when the player collides with something
    public void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "test" tag
        if (other.gameObject.CompareTag("test"))
        {
            // If it does, increase the player's score by 5 using the scoreScript
            scoreScript.AddScore(5);
            ps.Play();
            

        }
    }
    public void OnTriggerExit(Collider other)
    {
        // Check if the object the player collided with has the "test" tag
        if (other.gameObject.CompareTag("test"))
        {
            ps.Stop();

        }
    }
}
