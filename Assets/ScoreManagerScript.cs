using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{

    public Text scoreText;
    public Text displayText;
    int score;
    public void Score(int scoreValue)
    {
        score = score + scoreValue;
        Debug.Log(score);
        scoreText.text = score.ToString();
        
        
    }
}
