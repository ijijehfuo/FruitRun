using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 프리펩
// 레고 블록 세트
// 레고 블록세트는 여러개의 블록들로 구성되어있다.
// 이를 조합해서 원하는 구조물을 만들 수 있다.
// 마찬가지로 프리팹는 여러 컴포넌트(스크립, 콜라이더, 랜더러)로 구성된 게임오브젝트다.
// 이 프리팹능 사용해서 게임애에서 여러번 재사용하고 조합 할 수 있다.

// 원본과 복사본
// 인스턴스(복사본) 원본을 기준으로 복사된 애들이기 때문에
// 거울에 투영된 자기모습 => 화장을 했다 => 화장된 나의모습
// 원본을 수정하면 복사본도 수정된다.

// 개별 커스터마이징
// 레고 블록 세트로 만든 구조물은 개별적으로 추가적인 블록을 추가하거나 변경할 수 있다.
// 원본이 아닌 나룻배 => 돛 => 요트
// 원본 나룻배 => 요트
// 나룻배 10척
// 돛을 5개를 달면
// 나룻배 5, 요트 5척
// 커스터마이즈 원본을 건들이지 않고 복사본에 대해서 어떠한 처리를 하는것

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
      for (int i =0; i < 10; i ++)
        {
            GameObject instance = Instantiate(prefab);
            instance.transform.position = Vector3.zero + Vector3.up * i;
            instance.transform.name = i.ToString();
        }
    }

}
