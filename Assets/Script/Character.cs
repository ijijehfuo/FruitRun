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
}
