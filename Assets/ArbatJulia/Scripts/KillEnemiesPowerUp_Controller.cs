using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemiesPowerUp_Controller : MonoBehaviour
{
    // Variables para el PowerUp de killenemies
    [SerializeField] GameObject destroyEnemies_PowerUp;

    private Spawn_Enemy _spawnEnemy;

    public bool powerUpActivated;

    // Start is called before the first frame update
    void Start()
    {
        _spawnEnemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Spawn_Enemy>();
        
    }

    // Método para borrar todos los enemigos del array
    public void DeleteAllEnemies()
    {
        foreach (var enemies in _spawnEnemy.arrayEnemies)
        {
            Destroy(enemies.gameObject);
        }
    }
}
