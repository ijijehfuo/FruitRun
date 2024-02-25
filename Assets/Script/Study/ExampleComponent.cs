using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleComponent : MonoBehaviour
{
    // #include<stdio.h> => c
    // using => java, python, C#
    // 미리 공부를 시키는 코드

    //MonoBehaviour
    // 생명주기 B 와 D 사이의 C
    // awake, OnEnable, start, FixedUpdate, update, LateUpdate, OnDisable OnDestroy

    // 레고
    // 모양, 색별 분리된 파츠
    // 설계도 (기획)

    // 점토
    // 성 => 반죽으로 벽 / 반죽으로 벽돌
    // 벽돌 => 성

    // 레고 => 성

    // 컴포넌트패턴의 장점
    // 편리, 개발속도가 빨라진다
    // 단점
    // 자세히 조정이 힘들다!!!

    // 자식개체 찾기

    private void Awake()
    {
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);

        GameObject child = new GameObject();
        child.transform.parent = this.transform;
        child.AddComponent<SpriteRenderer>();
        child.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
        child.GetComponent<SpriteRenderer>().material.color = Color.blue;
        child.transform.parent = null;

        child.AddComponent<Rigidbody2D>();
        child.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
