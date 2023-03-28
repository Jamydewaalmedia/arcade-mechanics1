using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    NavMeshAgent Agent;
    private GameObject player;

    

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {
        if (player != null)
        {
            Agent.SetDestination(player.transform.position);
        }
        else
        {
            player = GameObject.Find("Player");
        }
        
    }


}