using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLaser : MonoBehaviour
{
    public GameObject laserPrefab;
    public float minShootDelay = 0f;
    public float maxShootDelay = 2f;
    public float bulletSpeed = 10f;

    private GameObject player;
    private float shootTimer;

    void Start()
    {
        // Find the player game object by tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Initialize the shoot timer with a random delay
        shootTimer = Random.Range(minShootDelay, maxShootDelay);
    }

    void Update()
    {
        // Update the shoot timer with the time since the last frame
        shootTimer -= Time.deltaTime;

        // Check if it's time to shoot and if the player is in front of the enemy
        Vector3 direction = player.transform.position - transform.position;
        if (shootTimer <= 0f && Vector3.Dot(direction, transform.forward) > 0f)
        {
            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Instantiate the laser prefab at the enemy's position and with the direction as initial velocity
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Rigidbody laserRigidbody = laser.GetComponent<Rigidbody>();
            laserRigidbody.velocity = direction * bulletSpeed;
            laserRigidbody.useGravity = false; // Disable gravity

            // Reset the shoot timer with a new random delay
            shootTimer = Random.Range(minShootDelay, maxShootDelay);
        }
    }
}
