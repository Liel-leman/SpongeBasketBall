using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInstantiation : MonoBehaviour {
    public GameObject ballPrefab;
    public void ins()
    {
        var position = new Vector2(Random.Range(-4, 4), Random.Range(-3.4f, 1));
        Instantiate(ballPrefab, position, Quaternion.identity);
    }// instantiate the ball in random place in the range i gave 
}
