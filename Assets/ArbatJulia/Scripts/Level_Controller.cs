using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Controller : MonoBehaviour
{
    // Variables
    private Text score_txt;
    private Text level_txt;
    private string level_name;

    // Start is called before the first frame update
    void Start()
    {
        // 
        score_txt = GameObject.FindGameObjectWithTag("score_txt").GetComponent<Text>();
        level_txt = GameObject.FindGameObjectWithTag("level_txt").GetComponent<Text>();

        UpdateActualSceneName();
        UpdateScoreUI();
    }

    // M�todo de actualizaci�n de nuestro texto de la UI con el nombre de la actual scene
    private void UpdateActualSceneName()
    {
        level_name = SceneManager.GetActiveScene().name;
        level_txt.text = level_name;
    }

    // M�todo de actualizaci�n de la Score en la UI
    public void UpdateScoreUI()
    {
        // Recuperac��n de la Score guardada en el Game_Manager
        int score = GameManager.instance.GetScoreGame();
        score_txt.text = "Score: " + score;
    }

    // M�todo que carga otra escena
    public void NextLevel(string nameNextScene)
    {
        SceneManager.LoadScene(nameNextScene);
    }
}
