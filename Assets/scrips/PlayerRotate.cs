
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float sensX;         // De gevoeligheid van de muisbeweging horizontaal
    public float sensY;         // De gevoeligheid van de muisbeweging verticaal
    [SerializeField] float xrotatie;
    [SerializeField] float negaxrotatie;

    public Transform orientation;   // De orientatie van de speler

    float xRotation;        // De rotatie van de speler om de x-as
    float yRotation;        // De rotatie van de speler om de y-as

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;     // Verberg de muiscursor
        Cursor.visible = true;                        // Maak de muiscursor zichtbaar
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;  // Beweging van de muis horizontaal
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;  // Beweging van de muis verticaal

        yRotation += mouseX;                // Voeg de horizontale muisbeweging toe aan de rotatie om de y-as

        xRotation -= mouseY;                // Trek de verticale muisbeweging af van de rotatie om de x-as

        xRotation = Mathf.Clamp(xRotation, negaxrotatie, xrotatie);   // Beperk de rotatie om de x-as tot tussen waarde van negarotatie en xrotatie
       

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);    // Pas de rotatie van de speler aan

        orientation.rotation = Quaternion.Euler(0, yRotation, 0);          // Pas de rotatie van de spelerorientatie aan
    }
}

