using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorState
{
    // 문에게는 어떤 상태가 있을까?
    Open = 0,
    Closed = 1,
}

public class FSMTester : MonoBehaviour
{
    public DoorState currentState;

    // FSM : Finite-State Machine (유한상태기록)
    // 제한된 상태 기계 = 꼭두각시 인형
    // 십자가로 된 컨트롤러 => 왼팔 오른팔 왼다리 오른다리 => 3번째 위로 왼다리를 든다.
    // 십자가 3번쨰 상승 = 왼다리를 들을 상태
    // 왼팔상태 오른팔상태 왼다리상태 오른다리상태 4가지 상태

    // 매니저패텬 싱글톤패텬 리스너패턴
    // 버튼만들기
    // 목적 : (버튼을 눌러서) <= 보여지는 역할 (숫자를 오르게할수도 있고 뭔가를 바꿀 수도 있다.) <= 이벤트
    // 목적을 달성할때 편하게 달성하기 위한 디자인 패텬이 만들어짐
    // 곱하기 기호 : 3 * 5 = 15 / 3 + 3 + 3 + 3 + 3 = 15

    // 실생활에서 사용되는 FSM
    // 신호등 - 빨간불 파란불 노란불, 전자레인지 - 시작, 정지, 해제, 문여닫기

    // enum => 열거형
    // 0 1 2 3 4 5

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case DoorState.Open:
                // 함수실행
                Opendoor();
                break;
            case DoorState.Closed:
                CloseDoor();
                break;
            default:
                break;
        }


    }

    private void Opendoor()
    {
        Debug.Log("문이 열렸습니다!!");
    }

    private void CloseDoor()
    {
        Debug.Log("문이 닫혀있습니다!!");
    }
}
