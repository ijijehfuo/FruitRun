using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressiveProperty : MonoBehaviour
{
    public float baseChance = 1f; // 기본 확률
    public float increasePerFail = 0.5f; // 실패시 증가 확률
    public float maxChance = 50f; // 최대 확률
    public float currentChance; // 현재 확률

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (TryGetItem() == true)
            {
                Debug.Log("흭득 성공!!");
            }
            else
            {
                Debug.Log("흭득 실패!!");
            }
        }
    }

    public bool TryGetItem()
    {
        if (Random.Range(0f, 100f) < currentChance)
        {
            ResetChance();
            return true;
        }
        else
        {
            increaseChance();
            return false;
        }
    }

    private void increaseChance()
    {
        currentChance += increasePerFail;
        if (currentChance > maxChance)
        {
            currentChance = maxChance;
        }
    }

    private void ResetChance()
    {
        currentChance = baseChance;
    }
}
