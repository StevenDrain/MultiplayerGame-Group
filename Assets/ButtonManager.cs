using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button StartGame;

    public Button EndGame;

    public Button Credits;
    
    void Start()
    {
        // Add a listener to the first button for when the button is clicked
        StartGame.onClick.AddListener(OnButton1Click);

        

        EndGame.onClick.AddListener(OnButton2Click);

        Credits.onClick.AddListener(OnButton3Click);
    }

    void OnButton1Click()
    {
       
        SceneManager.LoadScene("MoltenLevel");
    }

    void OnButton2Click()
    {
        Application.Quit();
    }

    void OnButton3Click()
    {
        SceneManager.LoadScene("Credits");
    }
}