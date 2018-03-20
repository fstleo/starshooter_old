using System;
using System.Collections.Generic;
using UnityEngine;

public static class UserSettings
{
    public static event Action OnUpdate;

    private static float _soundsVolume;
    public static float SoundsVolume
    {
        get
        {
            return _soundsVolume;
        }
        set
        {
            _soundsVolume = Mathf.Clamp01(value);            
            PlayerPrefs.SetFloat("Sounds_Volume", _soundsVolume);
            OnUpdate();
        }
    }

    private static float _musicVolume;
    public static float MusicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {           
            _musicVolume = Mathf.Clamp01(value);
            PlayerPrefs.SetFloat("Music_Volume", _musicVolume);
            OnUpdate();
        }
    }

    private static InputConfiguration _keyConfiguration;
    public static InputConfiguration KeyConfiguration
    {
        get
        {
            return _keyConfiguration;
        }
        set
        {
            _keyConfiguration = value;
        }
    }

    static UserSettings()
    {
        _soundsVolume = PlayerPrefs.GetFloat("Sounds_Volume", 1);
        _musicVolume = PlayerPrefs.GetFloat("Music_Volume", 1);
        _keyConfiguration = 
            JsonUtility.FromJson<InputConfiguration>(
                PlayerPrefs.GetString("InputConfiguration", 
                Resources.Load<TextAsset>("default_input_configuration").text)
                );
        OnUpdate += () => { };        
    }
}
