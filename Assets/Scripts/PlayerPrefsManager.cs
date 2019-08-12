using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_MUSIC_KEY = "master_music";
    const string SFX_KEY = "SFX";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_MUSIC_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterMusic()
    {
        return PlayerPrefs.GetFloat(MASTER_MUSIC_KEY);
    }


    public static void UnlockLevel(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= Application.levelCount - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query level not in build order");
            return false;
        }
    }


    public static void SetDifficulty(float SFX)
    {
        if (SFX >= 0f && SFX <= 1f)
        {
            PlayerPrefs.SetFloat(SFX_KEY, SFX);
        }
        else
        {
            Debug.LogError("SFX out of range");
        }
    }

    public static float GetSFX()
    {
        return PlayerPrefs.GetFloat(SFX_KEY);
    }
}