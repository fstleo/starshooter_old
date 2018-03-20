using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
            }
            return _instance;
            
        }
    }

    private Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    private Dictionary<string, string> eventSounds = new Dictionary<string, string>();
    private List<AudioClip> musicClips = new List<AudioClip>();

    AudioSource musicSource;
    AudioSource audioSource;    

    private void Awake()
    {
        DontDestroyOnLoad(this);
        musicSource = gameObject.AddComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
        UserSettings.OnUpdate += UpdateSoundSettings;
        UpdateSoundSettings();
        EventManager.Instance.AddListener<EventBaseData>(PlaySound);

        LoadConfig();
        LoadAudio();
        LoadMusic();
    }

    private void OnDestroy()
    {
        UserSettings.OnUpdate -= UpdateSoundSettings;
        if (EventManager.Instance != null)
        {
            EventManager.Instance.RemoveListener<EventBaseData>(PlaySound);
        }
    }

    private void Start()
    {
        PlayRandomMusic();
    }

    private void PlayRandomMusic()
    {
        if (musicClips.Count == 0)
            return;
        musicSource.clip = musicClips[Random.Range(0, musicClips.Count)];
        musicSource.loop = true;
        musicSource.Play();
    }

    private void LoadMusic()
    {        
        musicClips.AddRange(Resources.LoadAll<AudioClip>("Music"));
        
    }

    private void LoadConfig()
    {
        SoundsSet config = JsonUtility.FromJson<SoundsSet>(Resources.Load<TextAsset>("sounds_config").text);
        
        for (int i = 0; i < config.sounds.Length; i++)
        {
            eventSounds.Add(config.sounds[i].eventType, config.sounds[i].soundName);
        }
    }

    private void UpdateSoundSettings()
    {
        musicSource.volume = UserSettings.MusicVolume;
        audioSource.volume = UserSettings.SoundsVolume;        
    }

    private void LoadAudio()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds");
        foreach(var clip in clips)
        {
            sounds.Add(clip.name, clip);
        }
    }    

    private void PlaySound(EventBaseData ev)
    {
        if (eventSounds.ContainsKey(ev.GetType().ToString()))            
            PlaySound(eventSounds[ev.GetType().ToString()]);
    }

    public void PlaySound(string name)
    {
        audioSource.PlayOneShot(sounds[name]);
    }

}
