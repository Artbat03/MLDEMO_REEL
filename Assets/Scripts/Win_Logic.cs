using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Logic : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "MouseLabrynth_1")
            {
                SceneManager.LoadScene("MouseLabrynth_2");
                Timer_Controller.instancetimer.StartTimer();
                GameManager.instance.cheese = GameObject.FindGameObjectsWithTag("Cheese");
            }
            
            if (SceneManager.GetActiveScene().name == "MouseLabrynth_2")
            {
                StartCoroutine(YouWinAfter3SecondsMenu());
            }
        }
    }

    // Coroutine para volver al menu de la escena 1
    IEnumerator YouWinAfter3SecondsMenu()
    {
        yield return new WaitForSeconds(1);
        GameManager.instance.NextLevel("MouseLabrynth_Win");
        GameManager.instance.restartScore(0);
        Timer_Controller.instancetimer.StopTimer();
    }
}
