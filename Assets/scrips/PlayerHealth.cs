using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health;
    public int MaxHealth = 10;
    public MeshRenderer playermesh;
    public PlayerMovement playermovement;
    public MeshRenderer enemymesh;
    
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if(Health <= 0)
        {
            playermesh.enabled = false;
            playermovement.enabled = false;
            enemymesh.enabled = false;
            

            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
