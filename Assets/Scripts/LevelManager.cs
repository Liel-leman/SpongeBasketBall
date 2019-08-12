using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private GameObject toBeDestroyed;
    public float autoLoadNextLevelAfter;
    [SerializeField] bool winScreen;
    private GameObject quitButton;
    void Start()
    {
        if (winScreen == true)
        {
            StartCoroutine(Wait5sec());

        }
        if (autoLoadNextLevelAfter <= 0 )
        {
            Debug.Log("Level auto load disabled, use a postive number in seconds");
        }
        else
        {
          
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }
    IEnumerator Wait5sec()
    {
        yield return new WaitForSeconds(3);
        LoadLevel("04a TopScore");
    }
    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        quitButton = GameObject.FindGameObjectWithTag("ExitButton");
        quitButton.GetComponent<AudioSource>().Play();
        StartCoroutine(Wait2Sec());

    }
    IEnumerator Wait2Sec()
    {

        yield return new WaitForSeconds(2);
        Debug.Log("Quit requested");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void LoadMenu()
    {
        toBeDestroyed = GameObject.Find("GameSession");
        Destroy(toBeDestroyed);
        this.LoadLevel("01a Start");

    }
}
