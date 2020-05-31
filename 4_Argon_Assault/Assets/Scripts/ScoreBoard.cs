using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    
    int score;
    Text scoreTest;
    // Start is called before the first frame update
    void Start()
    {
        scoreTest = GetComponent<Text>();
        scoreTest.text = score.ToString();
    }
    public void scoreHit(int addScore)
    {
        score = score + addScore;
        scoreTest.text = score.ToString();
    }
    void Update()
    {
        
    }
}
