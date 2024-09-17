using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MachineState
{
    Washing = 0,
    Rinsing = 1,
    Drying = 2,
}

public class WashingMachine : MonoBehaviour
{
    // 목적 : 세탁(Washing), 헹굼(Rinsing), 건조(Drying)
    //     : 세탁 8초, 헹굼 4초, 건조 6초 
    //     : 세탁 : 이미지의 색을 파란색으로 이미지를 오른쪽 회, 8초가 지나면 헹굼 단계
    //     : 
    //     :

    public Image Clothes;
    public MachineState WashingProcess;
    private float WashingTime = 8f;
    private float RinsingTime = 4f;
    private float DryingTime = 6f;
    private float nowTime = 0f;
    private Color originColor;
    private bool _isFinish;

    void Start()
    {
        originColor = Clothes.color;
    }

    void Update()
    {
        if (_isFinish)
        {
            return;
        }
        nowTime += Time.deltaTime;

        switch (WashingProcess)
        {
            
            case MachineState.Washing:
                Clothes.color = Color.blue;
                if (nowTime >= WashingTime)
                {
                    nowTime = 0f;
                    WashingProcess = MachineState.Rinsing;
                }
                Clothes.transform.Rotate(-Vector3.forward);
                break;
            case MachineState.Rinsing:
                Clothes.transform.Rotate(Vector3.forward);
                if (nowTime >= RinsingTime)
                {
                    nowTime = 0f;
                    WashingProcess = MachineState.Drying;
                }
                break;
            case MachineState.Drying:
                Clothes.color = originColor;
                if (nowTime >= DryingTime)
                {
                    nowTime = 0f;
                    Debug.Log("세탁이 다 끝났습니다.");
                    _isFinish = true;
                }
                Clothes.transform.Rotate(-Vector3.forward);
                break;
            default:
                break;

        }
    }
}
