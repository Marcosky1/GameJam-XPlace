using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManagerController : MonoBehaviour
{
    [SerializeField] private VolumeData volumeData;
    [SerializeField] private SceneManagerController SceneManager;

    [SerializeField] private float CurrentTime;
    [SerializeField] private float StartTimeInSeconds;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private int CurrentMaleScore;
    [SerializeField] private int CurrentFemaleScore;
    [SerializeField] private TextMeshProUGUI MaleScore;
    [SerializeField] private TextMeshProUGUI FemaleScore;

    [SerializeField] private Slider Master;
    [SerializeField] private Slider Music;
    [SerializeField] private Slider SFX;
    [SerializeField] private GameObject VolumeHolder;

    void Start()
    {
        CurrentTime = StartTimeInSeconds;
        StartCoroutine(TimerBehaviorCycle());

        CurrentMaleScore = 0;
        CurrentFemaleScore = 0;

        Master.value = volumeData.GetValue("Master");
        Music.value = volumeData.GetValue("Music");
        SFX.value = volumeData.GetValue("SFX");
    }
    void Update()
    {
        volumeData.SetValues(Master.value, Music.value, SFX.value);
        volumeData.SetVolumeValues();

        if(CurrentTime <= 0)
        {
            if(CurrentMaleScore > CurrentFemaleScore)
            {
                SceneManager.P1Victory();
            }
            else if(CurrentFemaleScore > CurrentMaleScore)
            {
                SceneManager.P2Victory();
            }
            else
            {
                SceneManager.SceneToGo("MainMenu");
            }
        }
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
    public void UpdateScores(string victim, int score)
    {
        if (victim == "Male")
        {
            CurrentMaleScore += score;
            MaleScore.text = CurrentMaleScore.ToString();
        }
        else if(victim == "Female")
        {
            CurrentFemaleScore += score;
            FemaleScore.text = CurrentFemaleScore.ToString();
        }
    }
    public void ActiveVolumneSettings()
    {
        if (VolumeHolder.activeSelf)
        {
            VolumeHolder.SetActive(false);
        }
        else
        {
            VolumeHolder.SetActive(true);
        }
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