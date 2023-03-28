using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletforce1 : MonoBehaviour
{
    //life is hoe lang de bullet bestaat 3 is 3 seconde
    public float life = 3;

    private void Awake()
    {
        // Vernietig het game object waarop het script is gekoppeld na een bepaalde tijd
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vernietig het game object waarmee het huidige game object botst als het de "break" tag heeft
        if (collision.gameObject.CompareTag("break"))
        {
            Destroy(collision.gameObject);
        }

        // Vernietig het game object waarop het script is gekoppeld
        Destroy(gameObject);
    }
}
