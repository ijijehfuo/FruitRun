using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    // 카메라 선언
    // 떨리는 움직임 => 카메라의 Y축이나 Z축을 움직여서 덜리는 것 처럼 연출 +> 함수의 기능 Handle HandleCameraShake
    private float shakeDuration = 0f; // 쉐이크의 지속시간
    private float shakeMagnitude = 0.5f; // 쉐이크의 강도
    private float effectiveTime = 0.5f; // 쉐이크의 감소 속도
    private Vector3 originPositon; // 쉐이크 시작전의 카메라 위치
    private bool IsShake;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originPositon = transform.position;
    }

    private void Update()
    {
        if (IsShake)
        {
            // 연출
            HandleCameraShake();
            shakeDuration += Time.deltaTime;
            if (shakeDuration >= effectiveTime)
            {
                this.transform.position = originPositon;
                shakeDuration = 0f;
                IsShake = false;
            }
        }
    }

    private void HandleCameraShake()
    {
        transform.localPosition = originPositon + Random.insideUnitSphere * shakeMagnitude;
    }

    public void TriggerShake()
    {
        IsShake = true;
        shakeDuration = 0;
    }
}
