using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Controller : MonoBehaviour
{
    // Variables
    private Level_Controller _levelController;
    private Player_Controller _playerController;
    public int score;
  
    private void Start()
    {
        // 
        _levelController = GameObject.FindGameObjectWithTag("Level_Controller").GetComponent<Level_Controller>();
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerController.impowerup)
            {
                // Incremento del score + actualizaci�n del Game_Manager
                GameManager.instance.IncreaseScore(score*2);
            }

            else
            {
                // Incremento del score + actualizaci�n del Game_Manager
                GameManager.instance.IncreaseScore(score);
            }
            
            // Actualizaci�n de la UI con el level_Controller
            _levelController.UpdateScoreUI();

            // Destrucci�n del pickup
            Destroy(gameObject);
        }
    }
}
