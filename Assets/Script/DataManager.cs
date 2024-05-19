using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public UIMessagePopup MessagePopup;

    public int GameMoney;
    public int Cash;
    public Character SelectCharacter;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }
    
    public void SetSkill()
    {
        // SelectCharacter.Skills 첫번째 스킬
        // [] = 5개의 skill을 받을수 있어!
        // List = 너는 이제부터 skill을 받을 수 있어!
        // List.Add();

        for (int i = 0; i < SelectCharacter.Skills.Length; i++)
        {
            if (SelectCharacter.Skills[i].name.Contains("Speed"))
            {
                if (SelectCharacter.Skills[i].Intensity == intensity.Low)
                {
                    GameManager.Instance.ExtraSpeedRemainTime = 2;
                }

                else if (SelectCharacter.Skills[i].Intensity == intensity.High)
                {
                    GameManager.Instance.ExtraSpeedRemainTime = 5;
                }
            }

            if (SelectCharacter.Skills[i].Type == TYPE.Scale)
            {
                if (SelectCharacter.Skills[i].Intensity == intensity.Low)
                {
                    GameManager.Instance.ScaleExtraRemain = 2;
                }

                else if (SelectCharacter.Skills[i].Intensity == intensity.High)
                {
                    GameManager.Instance.ScaleExtraRemain = 5;
                }
            }
        }
    }

    public void GetGameMoney()
    {
        GameMoney = PlayerPrefs.GetInt("GameMoney");
    }

    public void SetGameMoney(int value)
    {
        GameMoney += value;
        PlayerPrefs.SetInt("GameMoney", GameMoney);
        MessagePopup.UpdateContent(value.ToString(), false);
    }
}

