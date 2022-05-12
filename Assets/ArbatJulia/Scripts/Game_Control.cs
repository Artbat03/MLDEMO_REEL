using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Control : MonoBehaviour
{
    [SerializeField] private GameObject startCamera;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private Timer_Controller timer;
    [SerializeField] private GameObject score_txt;

    void Start()
    {

        timer = FindObjectOfType<Timer_Controller>();
    }

    void Update()
    {
        // Logica para volver al menu principal
        if (Input.GetKeyDown(KeyCode.R))
        {
            endGame();
            
            if (SceneManager.GetActiveScene().name == "MouseLabrynth_1")
            {
                SceneManager.LoadScene("MouseLabrynth_1");
                transform.position = new Vector3(10.36f, 0, -13.6f);
            }

            if (SceneManager.GetActiveScene().name == "MouseLabrynth_2")
            {
                SceneManager.LoadScene("MouseLabrynth_2");
                transform.position = new Vector3(-3.5f, 0, -5f);
                transform.Rotate(0, 90, 0);
            }
        }
    }

    public void startGame()
    {
        // Logica mientras estamos jugando
        startCamera.SetActive(false);
        gameCamera.SetActive(true);
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        timer.startTimer();
        score_txt.SetActive(true);
    }

    public void endGame()
    {
        // Logica mientras estamos en el men� principal
        startCamera.SetActive(true);
        gameCamera.SetActive(false);
        menuUI.SetActive(true);
        gameUI.SetActive(false);
        score_txt.SetActive(false);
    }
}
