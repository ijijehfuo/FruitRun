using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public float playtimeWeight = 100f;
    public float CoinWeight = 500f;
    public int totalScore;
    public Text scoreText;
    public Image HpbarImage;
    public GameObject GameOverPopup;
    public GameObject GamePausePopup;

    public Button Jumpbutton;
    public Button SlideButton;
    public Button PauseButton;
    public PlayerController PlayerController;

    void Start()
    {
        Jumpbutton.onClick.AddListener(PlayerController.Jump);
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            GameManager.Instance.LastScore(totalScore);
            GameOverPopup.SetActive(true);
        }
        else if (GameManager.Instance.IsPause)
        {
            GamePausePopup.SetActive(true);
        }
        else
        {
            totalScore = (int)(GameManager.Instance.playTimeTimer * playtimeWeight + GameManager.Instance.EarnedCoin * CoinWeight);
            scoreText.text = totalScore.ToString();
            HpbarImage.fillAmount = GameManager.Instance.PlayerHP / GameManager.Instance.maxHP;
        }
    }
}
