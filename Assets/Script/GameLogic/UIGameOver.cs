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
        if (GameManager.Instance.Score > int.Parse(PlayerPrefs.GetString("HighScore")))
        {
            PlayerPrefs.SetString("HighScore", GameManager.Instance.Score.ToString());
        }
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
