using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStageSelect : MonoBehaviour
{
    public Transform SelectParent;
    public Button[] SelectButton;
    public Button ExitButton;

    void Start()
    {
        SelectButton = SelectParent.GetComponentsInChildren<Button>();

        // 목표 : 버튼을 눌렀을 때 Button_Stage_0 에서 0부분을 LevelManager에 등록!
        for (int i =0; i < SelectButton.Length; i++)
        {
            string name = SelectButton[i].transform.name;
            // name = Button_Stage_0
            string[] buttonList = name.Split('_');
            string StageNumber = buttonList[2];

            SelectButton[i].onClick.AddListener(() => LevelManager.Instance.StageIndex = int.Parse(StageNumber));
            SelectButton[i].onClick.AddListener(() => UISceneCanvas.Instance.OpenPopup(ButtonClickType.Stage));
        }

        ExitButton.onClick.AddListener(() => gameObject.SetActive(false));
    }
}
