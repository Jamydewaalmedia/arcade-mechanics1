using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class enemyles : MonoBehaviour
{
    public GameObject Player;
    private bool moveToLeft = true;
    public float center = 5;
    private float speed = 1;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != Player.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
       // if(moveToLeft)
       /* {

            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime;

            
            
           
        }
        else
        {
            transform.position += new Vector3(3,0,0) * Time.deltaTime;
        }

        if(transform.position.x <= center -5)
        {
            moveToLeft= false;
        }
        if(transform.position.x >= center + 5) 
        {
            moveToLeft= true;
        }*/
    }
}
