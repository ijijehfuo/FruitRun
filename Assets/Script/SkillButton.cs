using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Button Button;
    public Skill Skill;

    private void Start()
    {
        GetComponent<Image>().sprite = Skill.Icon;
    }
}
