using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Gate : MonoBehaviour
{

    public GameObject player;
    public Transform startingPoint;
    public GameObject enemyPrefab;

    private bool canTeleportAndSpawn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            canTeleportAndSpawn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            canTeleportAndSpawn = false;
        }
    }

    private void Update()
    {
        if (canTeleportAndSpawn && Input.GetKeyDown(KeyCode.E))
        {
            // Teleport the player to the starting point
            player.transform.position = startingPoint.position;

            // Spawn a new enemy
            Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Increment the enemy count
            EnemyManager.enemyCount++;

        }
    }

}

public static class EnemyManager
{
    public static int enemyCount = 0;
}


