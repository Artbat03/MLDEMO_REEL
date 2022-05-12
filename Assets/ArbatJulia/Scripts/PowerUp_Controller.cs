using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Controller : MonoBehaviour
{
    //Variables
    [SerializeField] private GameObject destroyEnemies_PowerUp;
    [SerializeField] private GameObject multiplyScore_PowerUp;

    public int score;

    private Enemy_Controller _EnemyController;
    private Spawn_Enemy _SpawnEnemy;
    private Level_Controller _levelController;
    private PickUp_Controller _PickUpController;

    // Start is called before the first frame update
    void Start()
    {
        _levelController = GameObject.FindGameObjectWithTag("Level_Controller").GetComponent<Level_Controller>();
    }

    // L�gica para el PowerUp de la poci�n
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncreaseScore(score);

            _levelController.UpdateScoreUI();

            Destroy(gameObject);
        }
    }
}
