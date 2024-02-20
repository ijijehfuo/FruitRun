using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSumExample : MonoBehaviour
{
    // 벡터
    // 벡터는 크기와 방향을 가진 양!
    // 0, 1 => 1, 1
    // x축 방향으로 1만큼 이동

    // (0,0) + (1,1) = (1,1)

    // (6 3 6)

    public GameObject Cube1;
    public GameObject Cube2;
    public GameObject resultCube;

    void Start()
    {
        // cube1솨 cube2의 위치 벡터를 합합니다.
        Vector3 sumPosition = Cube1.transform.position + Cube2.transform.position;

        // 결과 cube이 위치를 설정합니다.
        resultCube.transform.position = sumPosition;
    }

    void Update()
    {
        
    }
}
