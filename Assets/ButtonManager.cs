using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button StartGame;

    public Button EndGame;

    
    
    void Start()
    {
        // Add a listener to the first button for when the button is clicked
        StartGame.onClick.AddListener(OnButton1Click);

        

        EndGame.onClick.AddListener(OnButton2Click);

       
    }

    void OnButton1Click()
    {
       
        SceneManager.LoadScene("MineshaftLevel");
    }

    void OnButton2Click()
    {
        Application.Quit();
    }

    
}