using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE
{
    Speed,
    Scale,
}

public enum intensity
{
    Low,
    Middle,
    High,
}

[CreateAssetMenu(fileName = "newSkill", menuName = "Skill")]
public class Skill : ScriptableObject
{
    public string Name;
    public string Description;
    public TYPE Type;
    public intensity Intensity;
    public Sprite Icon;

}
