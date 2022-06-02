using UnityEngine;
using UnityEngine.UI;

public class Timer_Controller : MonoBehaviour
{
    // Variables
    public static Timer_Controller instancetimer;
    
    [SerializeField] private int minutes;

    [SerializeField] private int seconds;

    private int m, s;

    [SerializeField] private Text timer_Text;

    private void Awake()
    {
        instancetimer = this;
    }
   
    // Logica para comenzar la cuenta atras
    public void StartTimer()
    {
        m = minutes;
        s = seconds;
        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    // Logica para parar el contador
    public void StopTimer()
    {
        CancelInvoke();
    }

    // Logica para ejecucion en intervalos de 1 seg
    private void UpdateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                GameManager.instance.EndGame();
                return;
            }

            else
            {
                m--;
                s = 59;
            }
        }

        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    // Logica para escribir el timer
    private void WriteTimer(int m, int s)
    {
        if (s < 10)
        {
            timer_Text.text = m.ToString("0 0") + "  :  " + s.ToString("0 0");
        }
        else
        {
            timer_Text.text = m.ToString("0 0") + "  :  " + s.ToString("0 0");
        }
    }
}

