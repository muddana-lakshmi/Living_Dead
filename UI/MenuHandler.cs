using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainPanel;
    public float animationDuration = 1.0f;
    public void Startgame()
    {
        Debug.Log("you are started a new game");
        SceneManager.LoadScene("Zombie Game");
    }
    public void Resume()
    {
       
    }
    public void Quit()
    {
        
    }
    public void Settings()
    {
        
    }
}
