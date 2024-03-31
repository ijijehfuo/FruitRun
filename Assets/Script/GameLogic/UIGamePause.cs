using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGamePause : MonoBehaviour
{
    public Text ScoreText;
    public Button ContinueButton;
    public Button ExitButton;

    void Start()
    {
        ContinueButton.onClick.AddListener(Continue);
        ExitButton.onClick.AddListener(ChangeUIScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ChangeUIScene()
    {
        SceneManager.LoadScene("UIScene");
    }
}
