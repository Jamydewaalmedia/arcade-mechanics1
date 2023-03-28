using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class testles4 : MonoBehaviour
{
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int add)
    {
        score += add;
        Debug.Log(score);
    }
}
