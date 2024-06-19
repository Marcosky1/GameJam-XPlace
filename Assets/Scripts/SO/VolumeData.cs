using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "VolumeData", menuName = "ScriptableObjects/VolumeData", order = 1)]
public class VolumeData : ScriptableObject
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float Master;
    [SerializeField] private float Music;
    [SerializeField] private float SFX;
    public void SetValues(float master, float music, float sfx)
    {
        Master = master;
        Music = music;
        SFX = sfx;
    }
    public float GetProccessedValue(string victim)
    {
        if (victim == "Master")
        {
            return Mathf.Log10(Master) * 20f;
        }
        else if (victim == "Music")
        {
            return Mathf.Log10(Music) * 20f;
        }
        else if (victim == "SFX")
        {
            return Mathf.Log10(SFX) * 20f;
        }
        else
        {
            return 0f;
        }
    }
    public float GetValue(string victim)
    {
        if (victim == "Master")
        {
            return Master;
        }
        else if (victim == "Music")
        {
            return Music;
        }
        else if (victim == "SFX")
        {
            return SFX;
        }
        else
        {
            return 0f;
        }
    }
    public void SetVolumeValues()
    {
        audioMixer.SetFloat("_Master", GetProccessedValue("Master"));
        audioMixer.SetFloat("_Music", GetProccessedValue("Music"));
        audioMixer.SetFloat("_SFX", GetProccessedValue("SFX"));
    }
}