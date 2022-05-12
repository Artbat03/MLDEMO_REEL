using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Controller : MonoBehaviour
{

    // Variables y campos a usar
    [SerializeField] private int minutes;

    [SerializeField] private int seconds;

    private int m, s;

    [SerializeField] private Text timer_Text;

    private Game_Control gameControl;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = FindObjectOfType<Game_Control>();
    }

    // Logica para comenzar la cuenta atras
    public void startTimer()
    {
        m = minutes;
        s = seconds;
        writeTimer(m, s);
        Invoke("updateTimer", 1f);
    }

    // Logica para parar el contador
    public void stopTimer()
    {
        CancelInvoke();
    }

    // Logica para ejecucion en intervalos de 1 seg
    private void updateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                gameControl.endGame();
                return;
            }

            else
            {
                m--;
                s = 59;
            }
        }

        writeTimer(m, s);
        Invoke("updateTimer", 1f);
    }

    // Logica para escribir el timer
    private void writeTimer(int m, int s)
    {
        if (s < 10)
        {
            timer_Text.text = m + ":0" + s;
        }
        else
        {
            timer_Text.text = m + ":" + s;
        }
    }
}

