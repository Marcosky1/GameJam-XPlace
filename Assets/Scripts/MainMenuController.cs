using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private VolumeData volumeData;

    [SerializeField] private Slider Master;
    [SerializeField] private Slider Music;
    [SerializeField] private Slider SFX;
    [SerializeField] private GameObject VolumeHolder;

    void Start()
    {
        VolumeHolder.SetActive(false);
        Master.value = volumeData.GetValue("Master");
        Music.value = volumeData.GetValue("Music");
        SFX.value = volumeData.GetValue("SFX");

    }
    void Update()
    {
        volumeData.SetValues(Master.value, Music.value, SFX.value);
        volumeData.SetVolumeValues();
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
    public void Exit()
    {
        Application.Quit();
    }
}