using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatebruh : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        //Press the up arrow button to reset the trigger and set another one
        if (Input.GetKey(KeyCode.Space))
        {
            

            //Send the message to the Animator to activate the trigger parameter named "Jump"
            m_Animator.SetTrigger("Jump");
        }
    }
}
