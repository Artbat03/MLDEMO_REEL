using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn_Enemy : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject[] arraySpawnPoints;
    [SerializeField] public GameObject[] arrayEnemies;

    private int randomIndex_ArraySpawnPoints;
    private int randomIndex_ArrayEnemies;
    private GameObject currentSpawnPoint;
    private GameObject currentEnemy;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Manifesto de la coroutine
        StartCoroutine(GenerateEnemies());
    }

    IEnumerator GenerateEnemies()
    {
        // Coroutine que se ejecuta cada 10 segundos
        // También manifiesta el SelectRandomSpawnPosition y el InstantiateEnemy

        while (!isGameOver)
        {
            SelectRandomSpawnPosition();
            InstantiateEnemy();
            yield return new WaitForSeconds(10f);
        }
    }

    // Método que genera un número aleatorio en el array de spawns desde 0 hasta la longitud
    private void SelectRandomSpawnPosition()
    {
        // Num. aleatorio de 0 hasta la longitud actual del array de spwans
        randomIndex_ArraySpawnPoints = Random.Range(0, arraySpawnPoints.Length);

        // Actualización de los gameObject currentSpawnpoint para asociar la posición de los spawn
        currentSpawnPoint = arraySpawnPoints[randomIndex_ArraySpawnPoints];
    }

    // 
    private void InstantiateEnemy()
    {
        // Num. aleatorio de 0 hasta la longitud actual del array de enemies
        randomIndex_ArrayEnemies = Random.Range(0, arrayEnemies.Length);

        // Guardado de enemigos del array de enemigos que enemigo es del array index aleatorio
        currentEnemy = arrayEnemies[randomIndex_ArrayEnemies];

        // Instancia de enemigos préviamente guardados en el currentEnemy + pos. y rot. del spawn selected aleatoriamente
        Instantiate(currentEnemy, currentSpawnPoint.transform.position, currentSpawnPoint.transform.rotation);
    }
}
