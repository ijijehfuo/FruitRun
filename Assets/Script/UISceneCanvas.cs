using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ButtonClickType
{
    Start = 0,
    Stage = 1,
    Level = 2,
}

public class UISceneCanvas : MonoBehaviour
{
    public GameObject UI_CharacterSelect;
    public GameObject UI_Popup_Skill;
    public GameObject UI_UpperIcons;
    public GameObject UI_Popup_Message;
    public GameObject UI_StageSelect;
    public GameObject UI_LevelSelect;

    public Text GameMoneyText;
    public Text CashText;

    public static UISceneCanvas Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        // 아스키코드
        DataManager.Instance.GetGameMoney();

        GameMoneyText.text = DataManager.Instance.GameMoney.ToString();
        CashText.text = DataManager.Instance.Cash.ToString();
    }

    public void EarnGameMoney(int ExtraMoney)
    {
        DataManager.Instance.GameMoney += ExtraMoney;
        UpdateText();
        DataManager.Instance.MessagePopup.UpdateContent("골드를 " + ExtraMoney.ToString() + " 획득하셨습니다!", false);
    }

    public void EarnCash(int ExtraCash)
    {
        DataManager.Instance.Cash += ExtraCash;
        UpdateText();
        DataManager.Instance.MessagePopup.UpdateContent("케시를 " + ExtraCash.ToString() + " 획득하셨습니다!", true);
    }

    public void UpdateText()
    {
        GameMoneyText.text = DataManager.Instance.GameMoney.ToString();
        CashText.text = DataManager.Instance.Cash.ToString();
    }

    public void ClearPopup()
    {
        UI_StageSelect.gameObject.SetActive(false);
        UI_LevelSelect.gameObject.SetActive(false);
    }

    public void OpenPopup(ButtonClickType type)
    {
        ClearPopup();

        switch (type)
        {
            case ButtonClickType.Start:
                UI_StageSelect.gameObject.SetActive(true);
                break;
            case ButtonClickType.Stage:
                UI_LevelSelect.gameObject.SetActive(true);
                break;
            case ButtonClickType.Level:
                SceneManager.LoadScene("GameScene");
                // 씬 이동
                break;
            default:
                break;
        }
    }
}
