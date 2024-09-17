using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shopping();
        SeperateFood();
    }

    void Shopping()
    {
        string shoppingList = "아이패드,카메라,키보드,에어팟";
        // 목적 : 쇼핑리스트를 하나씩 분리한다!
        string[] items = shoppingList.Split(',');

        foreach (string item in items)
        {
            Debug.Log(item);
        }

    }

    void SeperateFood()
    {
        string shoppingList = "아이패드_1000000,카메라_450000,키보드_50000,에어팟_340000";
        string[] items = shoppingList.Split(',');
        // {아이패드_1000000, 카메라_450000, 키보드_50000, 에어팟_340000}
        // "아이패드"의 가격 : "1000000"

        foreach (string item in items)
        {
            string[] parts = item.Split('_');
            // parts[0], parts[1]
            string name = parts[0]; // 아이템 이름
            string date = parts[1]; // 가격

            Debug.Log(name + "의 가격 : " + date);
        }
    }
}
