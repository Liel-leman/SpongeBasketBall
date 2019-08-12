using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {
    public GameObject score;
    public GameObject scoreName;
    public GameObject rank;
 
    public void setScore(string name, string score,string rank)
    {
        this.rank.GetComponent<TextMeshProUGUI>().text = rank;
        this.scoreName.GetComponent<TextMeshProUGUI>().text = name;
        this.score.GetComponent<TextMeshProUGUI>().text = score;
    }

}
