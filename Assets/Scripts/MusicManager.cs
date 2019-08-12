using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destory on load: " + name);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        if (level != 3)
        {
            audioSource.Play();
            AudioClip thisLevelMusic = levelMusicChangeArray[level];
            Debug.Log("Playing clip: " + thisLevelMusic);

            if (thisLevelMusic)
            { // If there's some music attached
                audioSource.clip = thisLevelMusic;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Pause();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
