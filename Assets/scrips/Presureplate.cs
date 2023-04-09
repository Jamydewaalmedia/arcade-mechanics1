using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Presureplate : MonoBehaviour
{
    [SerializeField] float Countdown; // countdown timer voordat de brug verdwijnt
    public GameObject[] bridges; // array van bruggen

    private bool spelerOpPlaat = false; // of de speler op de drukplaat staat of niet

    // Start wordt aangeroepen voor de eerste frame-update
    void Start()
    {

    }

    void SetBridgeActive(int index, bool active)
    {
        bridges[index].SetActive(active); // methode om de actieve status van een brug in te stellen
    }

    // Update wordt één keer per frame aangeroepen
    void Update()
    {
        // Controleer of de speler niet op de drukplaat staat en de brug actief is
        if (!spelerOpPlaat)
        {
            for (int i = 0; i < bridges.Length; i++)
            {
                GameObject bridge = bridges[i];
                if (bridge.activeSelf)
                {
                    StartCoroutine(BrugVerdwijnen(i)); // start coroutine om brug te laten verdwijnen
                }
            }
        }
    }

    // coroutine om brug te laten verdwijnen na Countdown seconden
    private IEnumerator BrugVerdwijnen(int i)
    {
        // Wacht Countdown seconden voordat de brug verdwijnt
        yield return new WaitForSeconds(Countdown);
        SetBridgeActive(i, false); // maakt de brug inactief
    }

    // wanneer een object de trigger van de drukplaat betreedt
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("drukplaat is ingedrukt");

        // maak alle bruggen actief
        for (int i = 0; i < bridges.Length; i++)
        {
            SetBridgeActive(i, true);
        }
        spelerOpPlaat = true; // update spelerOpPlaat naar true
    }

    // wanneer een object de trigger van de drukplaat verlaat
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("speler is van de drukplaat af");

        spelerOpPlaat = false; // update spelerOpPlaat naar false
    }
}
