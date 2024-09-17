using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 애니메이션 걷기, 달리기, 가만히있기, 뛰기

public interface IState
{
    void Enter();

    void Execute();

    void Exit();
}

public class OnState : IState
{
    public void Enter()
    {
        Debug.Log("전구가 켜졌습니다.");
    }

    public void Execute()
    {
        Debug.Log("전구가 켜져있습니다.");
    }

    public void Exit()
    {
        Debug.Log("전구가 꺼질 준비가 되었습니다");
    }
}

public class OffState : IState
{
    public void Enter()
    {
        Debug.Log("전구가 꺼졌습니다");
    }

    public void Execute()
    {
        Debug.Log("전구가 꺼져 있습니다");
    }

    public void Exit()
    {
        Debug.Log("전구가 켜질 준비가 되었습니다");
    }
}

public class LightBulb : MonoBehaviour
{
    private IState currentState;

    void Start()
    {
        ChangeState(new OffState());
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeState(new OnState());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeState(new OffState());
        }

        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
