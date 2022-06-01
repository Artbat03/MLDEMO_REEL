using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    public static GameManager instance;

    [SerializeField] private int score_Counter;
    
    [SerializeField] private GameObject startCamera;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private Text score_txt;
    [SerializeField] private GameObject cheeseimg;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        
        menuUI.SetActive(true);
        gameUI.SetActive(false);
        
        restartScore(0);        
        
        Time.timeScale = 0;
        
        startCamera = GameObject.FindGameObjectWithTag("StartCamera");
        gameCamera = GameObject.FindGameObjectWithTag("GameCamera");
        gameCamera.SetActive(false);
    }

    private void Start()
    {
        cheeseimg.SetActive(false);
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
        UpdateScoreUI();
    }

    // Metodo de actualizacion de la Score en la UI
    public void UpdateScoreUI()
    {
        // Recuperacion de la Score guardada en el Game_Manager
        int score = GetScoreGame();
        score_txt.text = "" + score;
    }

    public void Restart()
    {
        // Logica para volver al menu principal
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            if (SceneManager.GetActiveScene().name == "MouseLabrynth_1")
            {
                EndGame();
                transform.position = new Vector3(11.5f, 0, -10.5f);
            }

            if (SceneManager.GetActiveScene().name == "MouseLabrynth_2")
            {
                EndGame();
                transform.position = new Vector3(-3.5f, 0, -5f);
                transform.Rotate(0, 90, 0);
            }
        }
    }
    
    // Metodo que carga otra escena
    public void NextLevel(string nameNextScene)
    {
        SceneManager.LoadScene(nameNextScene);
    }
    
    public void StartGame()
    {
        Time.timeScale = 1f;

        // Logica mientras estamos jugando
        startCamera.SetActive(false);
        gameCamera.SetActive(true);
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        Timer_Controller.instancetimer.StartTimer();
        cheeseimg.SetActive(true);
    }

    public void EndGame()
    {
        Time.timeScale = 0f;

        // Logica mientras estamos en el menu principal
        startCamera.SetActive(true);
        gameCamera.SetActive(false);
        menuUI.SetActive(true);
        gameUI.SetActive(false);
        cheeseimg.SetActive(false);
        restartScore(0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
