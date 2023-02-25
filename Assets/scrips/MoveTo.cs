using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    NavMeshAgent Agent;

    public Transform goal;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        
    }
    void Update()
    {
       Agent.SetDestination(goal.position);
    }


}