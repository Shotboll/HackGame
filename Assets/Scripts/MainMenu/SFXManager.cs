using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.VFX;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance; // Singleton

    [SerializeField] private AudioMixerGroup sfxMixerGroup;
    [SerializeField] private List<Sound> sounds = new List<Sound>();

    private Dictionary<string, AudioClip> sfxLibrary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSFXLibrary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeSFXLibrary()
    {
        foreach (Sound sound in sounds)
        {
            sfxLibrary.Add(sound.name, sound.clip);
        }
    }

    public void PlaySFX(string soundName, Vector3 position = default)
    {
        if (sfxLibrary.TryGetValue(soundName, out AudioClip clip))
        {
            GameObject soundObject = new GameObject("SFX_" + soundName);
            soundObject.transform.position = position;

            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = sfxMixerGroup;
            audioSource.clip = clip;
            audioSource.Play();

            Destroy(soundObject, clip.length + 0.1f);
        }
        else
        {
            Debug.LogWarning($"Sound {soundName} not found!");
        }
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}