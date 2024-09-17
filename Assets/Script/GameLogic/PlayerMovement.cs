using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 목적 : 캐릭터를 돌아다니게
    // 구현내용 : 화살표를 누르면 누른 방향으로 움직이게함
    // 필요한 변수: speed(float), transform

    public float speed = 5f;
    public RectTransform RectTransform;

    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        RectTransform.anchoredPosition += new Vector2(xMove, yMove);
    }
}
