using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMessagePopup : UIPopup
{
    public Image MoneyIcon;
    public Text MessageText;
    public Button CloseButton;
    public Sprite CashSprite;
    public Sprite MoneySprite;

    private void Start()
    {
        CloseButton.onClick.AddListener(() => GetComponent<Animator>().SetTrigger("Close"));
    }

    public void UpdateContent(string message, bool isCash)
    {
        
        MessageText.text = message;
        if (isCash)
        {
            MoneyIcon.sprite = CashSprite;
        }
        else
        {
            MoneyIcon.sprite = MoneySprite;
        }

        Onstart();
    }
}
