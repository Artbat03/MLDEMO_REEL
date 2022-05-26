using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyPowerUp_Controller : MonoBehaviour
{
    //Variables para el PowerUp de multiplicar x2 el score
    private Player_Controller _playerController;

    public int score;
          
    void Start()
    {
        // Recuperamos el script del player
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();   
    }

    // Logica para el PowerUp de multiplicar x2 la score
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Incremento del score + actualizacion del Game_Manager
            GameManager.instance.IncreaseScore(score++);

            // Coroutine para que el efecto dure 10 segundos
            StartCoroutine(MultiplyPointsDuring15Seconds());

            // Actualizacion de la UI con el level_Controller
            GameManager.instance.UpdateScoreUI();

            // Destruccion del pickup
            Destroy(gameObject);
        }
    }

    // Coroutine para el PowerUp de multiplicar x2 la score
    IEnumerator MultiplyPointsDuring15Seconds()
    {
        _playerController.impowerup = true;
        yield return new WaitForSeconds(15);
        _playerController.impowerup = false;
    }
}
