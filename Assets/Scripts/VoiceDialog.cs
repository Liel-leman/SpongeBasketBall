using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[System.Serializable]
public class VoiceDialog : MonoBehaviour {
    public BallInstantiation ballInstantiation;
    public TextMeshProUGUI textDisplay;
    [TextArea(3, 10)]
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private bool colorTMPro;//for typing coroutine( to realize key sensetive words)
    public GameObject dialogBox;
    [Header("Nets")]
    public GameObject leftNet;
    public GameObject rightNet;
    [Header("Basket Display")]

    public AudioClip[] rightWordsVoice;
    private int rightIndex;
    


    public AudioClip[] leftWordsVoice;
    private int leftIndex;
    
    [Header("what basket is working ? on the existense lvl")]
    public string[] Right_left_Net;
    private int R_L_index;


    LevelManager levelManager;

    /// </summary>


    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        ballInstantiation = FindObjectOfType<BallInstantiation>().GetComponent<BallInstantiation>();
        colorTMPro = false;
        StartCoroutine(Type());

        ballInstantiation.ins();
    }

    private void Update()
    {
        //if (textDisplay.text == sentences[index])
        //{
        //    //dialogBox.SetActive(true);
        //}

    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())//primery txt
        {
            if (letter == '<') colorTMPro = true;
            if (letter == '>') colorTMPro = false;
            textDisplay.text += letter;
            if (colorTMPro == false)
            {
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        ActivateRightNet();

    }

    public void NextSentense()
    {
        //dialogBox.SetActive(false);
        dialogBox.SetActive(true);
        if (index < sentences.Length - 1)
        {
            index++;
            leftIndex++;
            rightIndex++;
            R_L_index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            //ballInstantiation.ins();
        }
        else
        {
            textDisplay.text = "";
            levelManager.LoadNextLevel();
        }
    }

    public void ActivateRightNet()
    {
        if (Right_left_Net[R_L_index] == "Right")
        {
            leftNet.SetActive(false);
            rightNet.SetActive(true);
        }
        else
        {
            rightNet.SetActive(false);
            leftNet.SetActive(true);
        }

    }
    public AudioClip LeftSoundToPlay()
    {
        return leftWordsVoice[leftIndex];
    }
    public AudioClip rightSoundToPlay()
    {
        return  rightWordsVoice[rightIndex];
    }
}
