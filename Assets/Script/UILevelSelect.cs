using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelSelect : MonoBehaviour
{
    public Transform LevelParent;
    public Button[] LevelButtons;

    void Start()
    {
        LevelButtons = LevelParent.GetComponentsInChildren<Button>();

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            string name = LevelButtons[i].name;
            string[] LevelList = name.Split('_');
            int LevelNumber = int.Parse(LevelList[2]);

            LevelButtons[i].onClick.AddListener(() => LevelManager.Instance.LevelIndex = LevelNumber);
        }
    }

}
