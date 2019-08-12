using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour {
    private bool gameOver;
    LevelManager levelManager;
    public Sprite[] heartSprites;
    public Image HeartUI;
    public int currHealth=5;
    public int pointsPerGoal = 50;
    public TextMeshProUGUI scoreText;
    public int currentScore=0;
    [Header("Timer")]
    public float startTime;
    public string timerTime;
    // Use this for initialization
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start () {
        startTime = Time.time;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        scoreText.text = currentScore.ToString();
        gameOver = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (currHealth >= 0)
        {
            HeartUI.sprite = heartSprites[currHealth];
        }
        if(currHealth<=0 && gameOver == false)
        {
            levelManager.LoadLevel("03b Lose");
            gameOver = true;
        }
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        if(t%60 >=10)
        {
            timerTime = minutes + ":" + seconds;
        }
        else
        {
            timerTime = minutes + ":0" + seconds;//display more clearly the seconds
        }
        

    }
    public void UpdateHealth(int num)
    {
        currHealth += num;
    }

    public void AddToScore()
    {
        currentScore += pointsPerGoal;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
