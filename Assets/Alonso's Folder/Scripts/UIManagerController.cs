using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float StartTimeInSeconds = 60f;
    private float CurrentTime;
    [SerializeField] private TextMeshProUGUI timerText;
    void Start()
    {
        CurrentTime = StartTimeInSeconds;
        StartCoroutine(TimerBehaviorCycle());
    }

    public IEnumerator TimerBehaviorCycle()
    {
        while (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            UpdateTimerDisplay();
            yield return null;
        }
        TimerFinished();
    }
    public void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(CurrentTime / 60);
        int seconds = Mathf.FloorToInt(CurrentTime % 60);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    public void TimerFinished()
    {
        CurrentTime = 0;
        UpdateTimerDisplay();
    }
}