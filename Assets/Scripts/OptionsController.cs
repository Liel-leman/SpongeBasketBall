using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour
{

    public Slider MusicSlider, SFXSlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

    // Use this for initialization
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        MusicSlider.value = PlayerPrefsManager.GetMasterMusic();
        SFXSlider.value = PlayerPrefsManager.GetSFX();
    }

    // Update is called once per frame
    void Update()
    {
        musicManager.SetVolume(MusicSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(MusicSlider.value);
        PlayerPrefsManager.SetDifficulty(SFXSlider.value);
        levelManager.LoadLevel("01a Start");
    }

    public void SetDefaults()
    {
        MusicSlider.value = 0.8f;
        SFXSlider.value = 1f;
    }
}
