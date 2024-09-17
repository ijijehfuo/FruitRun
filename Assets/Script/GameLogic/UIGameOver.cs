using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    // 1. 스코어
    // 2. 리트라이
    // 3. 나가기
    public Text ScoreText;
    public Button RetryButton;
    public Button ExitButton;

    void Start()
    {
        RetryButton.onClick.AddListener(RestartScene);
        ExitButton.onClick.AddListener(ChangeUIScene);

        int highScore;
        if (!int.TryParse(PlayerPrefs.GetString("HighScore"), out highScore))
        {
            highScore = 0; // 변환 실패 시 기본값 설정
        }
        if (GameManager.Instance.Score > highScore)
        {
            PlayerPrefs.SetString("HighScore", GameManager.Instance.Score.ToString());
        }
        DataManager.Instance.SetGameMoney(GameManager.Instance.Score / 100);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = GameManager.Instance.Score.ToString();
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ChangeUIScene()
    {
        SceneManager.LoadScene("UIScene");
    }
}
