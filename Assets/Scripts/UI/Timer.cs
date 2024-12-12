
using TMPro; // Используйте, если работаете с TextMeshPro
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Привяжите текстовый объект сюда
    public float totalTime = 0; // Таймер на 5 минут (300 секунд)

    private void Update()
    {
        //Увеличение времени таймера
        totalTime += Time.deltaTime;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(totalTime / 60);
        int seconds = Mathf.FloorToInt(totalTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // private void TimerFinished()
    // {
    //     Debug.Log("Таймер завершён!");
    //     // Здесь можно вызвать действия по завершению таймера
    // }
}
