using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStageSelect : MonoBehaviour
{
    public Button[] SelectButton;

    void Start()
    {
        // 목표 : 버튼을 눌렀을 때 "this is Button + {transform.name}
        for (int i =0; i < SelectButton.Length; i++)
        {
            string name = SelectButton[i].transform.name;
            SelectButton[i].onClick.AddListener(() => Debug.Log("this is Button " + name));
        }

    }
}
