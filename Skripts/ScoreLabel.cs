using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour
{
   [SerializeField] private Text scoreLabel;
    
    static public int score;
    

    public void SetScore(string scoreValue)
    {
        scoreLabel.text = scoreValue;
    }
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if (value != score)
            {
                score = value;
                SetScore(score.ToString());
            }

        }
    }

}
