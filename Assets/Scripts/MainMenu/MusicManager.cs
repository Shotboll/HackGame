using UnityEditor;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioClip gameMusic;

    private AudioSource audioSource;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // не уничтожается при загрузке главной сцены с игрой
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = gameMusic;
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject); // уничтожает дубликаты
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
