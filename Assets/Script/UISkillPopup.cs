using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillPopup : UIPopup
{
    public static UISkillPopup Instance;

    public Skill SkillData;
    public Text TitleText;
    public Text Description;
    public Image Skill_Icon;

    private void Awake()
    {
        Instance = this;
    }

    public void SetData(Skill Data)
    {
        SkillData = Data;
    }

    // 상속, 추상클래스
    // 적(enemy) => 이동, 공격, 피해받기
    // 좀비 => 적
    // 로봇 => 적
    // 야수 => 적

    override protected void Onstart()
    {
        UpdateContents();
        base.Onstart();
    }

    public void Open()
    {
        Onstart();
    }

    private void UpdateContents()
    {
        ResetContents();
        TitleText.text = SkillData.Name;
        Description.text = SkillData.Description;
        Skill_Icon.sprite = SkillData.Icon;
    }
    private void ResetContents()
    {
        TitleText.text = "";
        Description.text = "";
        Skill_Icon.sprite = null;
    }
}
