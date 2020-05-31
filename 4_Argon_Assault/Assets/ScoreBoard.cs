using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scoreForHit = 5;
    int score;
    Text scoreTest;
    // Start is called before the first frame update
    void Start()
    {
        scoreTest = GetComponent<Text>();
        scoreTest.text = score.ToString();
    }
    public void scoreHit()
    {
        score = score + scoreForHit;
        scoreTest.text = score.ToString();
    }
    void Update()
    {
        
    }
}
