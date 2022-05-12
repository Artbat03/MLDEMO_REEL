using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win_Logic : MonoBehaviour
{
    public Text victory;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "MouseLabrynth_1")
            {
                SceneManager.LoadScene("MouseLabrynth_2");
            }
            
            if (SceneManager.GetActiveScene().name == "MouseLabrynth_2")
            {
                //victory.text = GameObject.FindGameObjectWithTag("Victorytxt").GetComponent<Text>();
                victory.gameObject.SetActive(true);
                StartCoroutine(YouWinAfter3SecondsMenu());
            }
        }
    }

    // Coroutine para volver al menu de la escena 1
    IEnumerator YouWinAfter3SecondsMenu()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MouseLabrynth_1");
        GameManager.instance.restartDefaultScore();
    }
}
