using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGamePause : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider SFXSlider;

    public Button ContinueButton;
    public Button ExitButton;

    void Start()
    {
        BGMSlider.value = audioManager.Instance.MusicSource.volume;
        SFXSlider.value = audioManager.Instance.SfxSource.volume;

        BGMSlider.onValueChanged.AddListener(OnBGMSliderChanged);
        SFXSlider.onValueChanged.AddListener(OnSFXSliderChanged);

        ContinueButton.onClick.AddListener(Continue);
        ExitButton.onClick.AddListener(ChangeUIScene);
    }

    private void OnBGMSliderChanged(float value)
    {
        audioManager.Instance.MusicSource.volume = value;
    }

    private void OnSFXSliderChanged(float value)
    {
        audioManager.Instance.SfxSource.volume = value;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Continue()
    {
        GameManager.Instance.GameContinue();
        gameObject.SetActive(false);
    }

    private void ChangeUIScene()
    {
        SceneManager.LoadScene("UIScene");
    }
}
