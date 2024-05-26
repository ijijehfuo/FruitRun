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
}
