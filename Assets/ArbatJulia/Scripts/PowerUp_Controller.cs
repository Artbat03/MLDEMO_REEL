using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Controller : MonoBehaviour
{
    //Variables
    public int score;

    private Enemy_Controller _EnemyController;
    private Spawn_Enemy _SpawnEnemy;
    private PickUp_Controller _PickUpController;

    // Logica para el PowerUp de la pocion
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncreaseScore(score);

            GameManager.instance.UpdateScoreUI();

            Destroy(gameObject);
        }
    }
}
