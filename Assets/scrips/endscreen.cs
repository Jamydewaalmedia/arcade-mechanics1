using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endscreen : MonoBehaviour
{
  
    public void Quitgame()
    {
        Application.Quit();
        Debug.Log("game is gone");
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
