using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyPowerUp_Controller : MonoBehaviour
{
    //Variables para el PowerUp de multiplicar x2 el score
    [SerializeField] private GameObject multiplyScore_PowerUp;

    private Level_Controller _levelController;
    private Player_Controller _playerController;

    public int score;
          
    // Start is called before the first frame update
    void Start()
    {
        _levelController = GameObject.FindGameObjectWithTag("Level_Controller").GetComponent<Level_Controller>();
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();   
    }

    // L�gica para el PowerUp de multiplicar x2 la score
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Incremento del score + actualizaci�n del Game_Manager
            GameManager.instance.IncreaseScore(score++);

            // Coroutine para que el efecto dure 10 segundos
            StartCoroutine(MultiplyPointsDuring15Seconds());

            // Actualizaci�n de la UI con el level_Controller
            _levelController.UpdateScoreUI();

            // Destrucci�n del pickup
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
