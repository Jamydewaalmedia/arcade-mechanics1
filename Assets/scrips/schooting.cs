using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class schooting : MonoBehaviour
{
    public Transform Barrel;
    public GameObject bulletPrefab;
    public float bullletSpeed = 10f;

    private void Update()
    {
        // press space to schoot an prefab of the bullet prefab 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var dog = Barrel.position;
            Debug.Log(dog);
            var bullet = Instantiate(bulletPrefab, Barrel.position, Barrel.rotation);

            bullet.GetComponent<Rigidbody>().velocity = Barrel.forward * bullletSpeed;
        }
    }
}
