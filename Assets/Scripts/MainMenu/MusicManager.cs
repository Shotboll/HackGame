using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;

    private AudioSource audioSource;
    private string currentSceneName;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // не уничтожается при загрузке главной сцены с игрой
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded; // Подписываемся на событие загрузки сцены
        }
        else
        {
            Destroy(gameObject); // уничтожает дубликаты
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string newSceneName = scene.name;

        // Меняем музыку только при переходе между меню и игрой
        if (currentSceneName == newSceneName) return;

        if (newSceneName == "MainMenu")
        {
            PlayMusic(menuMusic);
        }
        else if (newSceneName == "Pensioner's Chaotic Lab")
        {
            PlayMusic(gameMusic);
        }

        currentSceneName = newSceneName;
    }

    private void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip && audioSource.isPlaying) return;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SwitchToMenuMusic() => PlayMusic(menuMusic);
    public void SwitchToGameMusic() => PlayMusic(gameMusic);
}
