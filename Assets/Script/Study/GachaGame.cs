using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaGame : MonoBehaviour
{
    // 모든 아이템이 나올 확률이 같지 않고 일부아이템들이 다른 아이템들보다 드물게 나온다.
    // 예를 들면 희귀아이템은 나올확률이 5% 일반 아이템은 나올확률이 95%
    // 가중치랜덤이란 여기서 나오는 확률 5% 95%이 부분을 조절하는 개념

    // 아이템과 가중치
    private string[] items = { "전설 아이템", "영웅 아이템", "희귀 아이템" };
    private int[] weights = { 5, 25, 80 };

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayGacha();
        }
    }

    private void PlayGacha()
    {
        int totalweight = 0;

        foreach (int weight in weights)
        {
            totalweight += weight;
        }

        int randomvalue = Random.Range(0, totalweight);

        for (int i = 0; i < items.Length; i++)
        {
            if (randomvalue < weights[i])
            {
                Debug.Log(items[i] + "!!" + randomvalue);
                break;
            }
            randomvalue -= weights[i];
        }
    }
}
