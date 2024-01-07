using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static UISceneCanvas Instance;

    private void Awake()
    {
        Instance = this;
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
                // 씬 이동
                break;
            default:
                break;
        }
    }
}
