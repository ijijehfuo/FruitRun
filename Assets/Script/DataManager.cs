using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public UIMessagePopup MessagePopup;
    public Text GameMoneyText;
    public Text CashText;

    public int GameMoney;
    public int Cash;

    public void Start()
    {
        // 아스키코드
        GameMoneyText.text = GameMoney.ToString();
        CashText.text = Cash.ToString();
    }

    public void EarnGameMoney(int ExtraMoney)
    {
        GameMoney += ExtraMoney;
        UpdateText();
        MessagePopup.UpdateContent("골드를 " + ExtraMoney.ToString() + " 획득하셨습니다!", false);
    }

    public void EarnCash(int ExtraCash)
    {
        Cash += ExtraCash;
        UpdateText();
        MessagePopup.UpdateContent("케시를 " + ExtraCash.ToString() + " 획득하셨습니다!", true);
    }

    public void UpdateText()
    {
        GameMoneyText.text = GameMoney.ToString();
        CashText.text = Cash.ToString();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EarnGameMoney(100);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            EarnCash(100);
        }
    }

}
