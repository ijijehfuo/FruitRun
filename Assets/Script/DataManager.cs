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
        Instance = this;
        DontDestroyOnLoad(this);
    }

}

