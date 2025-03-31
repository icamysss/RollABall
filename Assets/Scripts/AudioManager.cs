using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(PlayRandomBackGroundSound(1));
    }

    IEnumerator PlayRandomBackGroundSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        var s = GetRandomBackGroundSound();
        s.source.Play();
        StartCoroutine(PlayRandomBackGroundSound(s.clip.length));
    }
    
    
    public AudioClip GetRandomBackGroundClip()
    {
        List<AudioClip> clips = new List<AudioClip>();
        foreach (var s in sounds)
        {
            if (s.clip != null &&  s.type == SoundType.Background)
            {
                clips.Add(s.clip);
            }
        }
        return clips[UnityEngine.Random.Range(0, clips.Count)];
    }
    
    public Sound GetRandomBackGroundSound()
    {
        List<Sound> clips = new List<Sound>();
        foreach (var s in sounds)
        {
            if (s != null &&  s.type == SoundType.Background)
            {
                clips.Add(s);
            }
        }
        return clips[UnityEngine.Random.Range(0, clips.Count)];
    }

    public AudioClip GetFirstClipByType(SoundType type)
    {
        foreach (var s in sounds)
        {
            if (s.type == type)
                return s.clip;
        }
        return null;
    }

    public void Click()
    {
        audioSource.PlayOneShot(GetFirstClipByType(SoundType.Click));
    }

    public void Collect()
    {
        audioSource.PlayOneShot(GetFirstClipByType(SoundType.Collect));
    }

    public void Win()
    {
        audioSource.PlayOneShot(GetFirstClipByType(SoundType.Win));
    }

    public void Lose()
    {
        audioSource.PlayOneShot(GetFirstClipByType(SoundType.Loose));
    }
    
    
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    

    private void OnValidate()
    {
        foreach (var s in sounds)
        {
            if (s.clip != null)
            {
                s.name = s.clip.name;
            }
        }
    }
}

public enum SoundType
{
    Click, Background, Win, Loose, Collect
}
[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] public float volume;
    [Range(-3f, 3f)] public float pitch;
    public bool loop;
    public SoundType type;
    [HideInInspector]
    public AudioSource source;
}