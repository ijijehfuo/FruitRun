using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDifferenceExample : MonoBehaviour
{
    // 유니티 하이라키 창에서 직접 오브젝트를 넣어줄 수 있다
    // 프라이빗으론 안되나?
    // 프라이빗으로도 할 수 있다 -> SerializeField를 붙이면 된다!

    // 프라이빗으로 쎴을때 좋은점?
    // 다른 곳에서 찾아올 수 없다.
    // 외부코드에서의 접근을 막아서 코드의 안정성을 높일 수 있다
    // 단일책임원칙 SOLID -> 코드하나는 코드하나의 역할을 해야 한다.

    // 퍼블릭으로 쎴을때 좋은점?
    // 다른곳에서 찾아올 수 있다.
    // 코드애서 쉽게 바꿀 수 있다 => 게임 스피드 같이 다른 코드에도 써야 하는 것들을 바꿔야 할때 쓸수 있다.
    // 빨리 개발할때도 프로토타이핑 사용

    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject ResultCube;

    void Start()
    {

    }

    // 프레임
    // 60fps
    // frame per second
    // 1초에 60번 0.02 - 0.03초

    void Update()
    {
        Vector3 DiffPosition = Cube1.transform.position - Cube2.transform.position;
        ResultCube.transform.position = DiffPosition;
    }
}
