using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "newCharacter", menuName = "Character")]
public class Character : ScriptableObject
{
    public string Name;
    public string Description;
    public string Ability;
    public float Health;
    public SpriteLibraryAsset Asset;
    public Skill[] Skills;
    public int Price;
    public int Level;
    public int Experience;

    public int MaxExperience = 5;

    public bool IsPurchased
    {
        get => PlayerPrefs.GetInt($"Character_{Name}_Purchased", 0) == 1;
        set
        {
            if (value == true)
            {
                PlayerPrefs.SetInt($"Character_{Name}_Purchased", 1);
            }
            else
            {
                PlayerPrefs.SetInt($"Character_{Name}_Purchased", 0);
            }
        }
    }

    public void AddExperience()
    {
        Experience++;

        if (Experience >= MaxExperience)
        {
            Level++;
            Experience = 0;
        }

        SaveCharacterData();
    }

    public void SaveCharacterData()
    {
        PlayerPrefs.SetInt($"Character_{Name}_Level", Level);
        PlayerPrefs.SetInt($"Character_{Name}_Experience", Experience);
    }

    public void LoadCharacterData()
    {
        Level = PlayerPrefs.GetInt($"Character_{Name}_Level", 1);
        Experience = PlayerPrefs.GetInt($"Character_{Name}_Experience", 0);
    }
}
