using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    public static GameManager instance;

    [SerializeField] private int score_Counter;

    private Level_Controller _levelController;
    
    [SerializeField] private GameObject startCamera;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private Timer_Controller timer;
    [SerializeField] private GameObject score_txt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            _levelController = GameObject.FindGameObjectWithTag("Level_Controller").GetComponent<Level_Controller>();
        }

        else
        {
            Destroy(gameObject);
        }
        
        timer = FindObjectOfType<Timer_Controller>();
    }

    private void Update()
    {
        Restart();
    }

    // Metodo que indica el valor de la score actualizado
    public int GetScoreGame()
    {
        return score_Counter;
    }

    // Metodo que aumenta el score_Counter
    public void IncreaseScore(int score)
    {
        score_Counter += score;
    }

    // Metodo para reestablecer los puntos desde cero
    public void restartScore(int score_Counter)
    {
        this.score_Counter = score_Counter;
    }

    // 
    public void restartDefaultScore()
    {
        score_Counter = 0;
        _levelController.UpdateScoreUI();

    }

    public void Restart()
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