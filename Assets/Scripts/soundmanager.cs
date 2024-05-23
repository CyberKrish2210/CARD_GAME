using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundmanager : MonoBehaviour
{
    private static soundmanager instance;

    public static soundmanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<soundmanager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("SoundManager");
                    instance = obj.AddComponent<soundmanager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensure that this object persists across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Load volume settings
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        UpdateVolume();
    }

    public void ChangeVolume(Slider volumeSlider)
    {
        AudioListener.volume = volumeSlider.value;
        Save(volumeSlider.value);
    }

    private void Save(float volume)
    {
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void UpdateVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SetVolumeSlider(Slider slider)
    {
        if (slider != null)
        {
            slider.value = PlayerPrefs.GetFloat("musicVolume");
            slider.onValueChanged.AddListener(delegate { ChangeVolume(slider); });
        }
    }
}
