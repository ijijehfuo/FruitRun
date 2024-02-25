using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float playtimeWeight = 100f;
    public float CoinWeight = 500f;
    public int totalScore;
    public Text scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        totalScore = (int)(GameManager.Instance.playTimeTimer * playtimeWeight + GameManager.Instance.EarnedCoin * CoinWeight);
        scoreText.text = totalScore.ToString();
    }
}
