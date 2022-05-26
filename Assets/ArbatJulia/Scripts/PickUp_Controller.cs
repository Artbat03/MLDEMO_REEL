using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Controller : MonoBehaviour
{
    // Variables
    private Player_Controller _playerController;
    public int score;
  
    private void Start()
    {
        // Recuperamos el script del player
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_playerController.impowerup)
            {
                // Incremento del score + actualizacion del Game_Manager
                GameManager.instance.IncreaseScore(score*2);
            }

            else
            {
                // Incremento del score + actualizacion del Game_Manager
                GameManager.instance.IncreaseScore(score);
            }
            
            // Actualizacion de la UI con el level_Controller
            GameManager.instance.UpdateScoreUI();

            // Destruccion del pickup
            Destroy(gameObject);
        }
    }
}
