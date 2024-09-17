using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LightColor
{
    Red = 0,
    Orange = 1,
    Green = 2,
}

public class TrafficLight : MonoBehaviour
{
    // 목적 : 빨간불, 주황불, 초록불의 색이 존재
    //     : 각각의 색에 지정된 시간을 부여
    //     : 빨간불 3초, 주황불 1초 초록불 4초
    //     : 각각의 불에는 이미지가 그 색으로 바뀌어야한다
    //     : 각각의 남은시간이 텍스트로 보여줘야한다.

    public LightColor trafficColor;
    public Image ColorImage;
    public Text ColorText;
    private float _redTime = 3f;
    private float _orangeTime = 1f;
    private float _greenTime = 4f;
    private float targetTime = 0f;
    private float nowTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;

        switch (trafficColor)
        {
            case LightColor.Red:
                targetTime = _redTime;
                if (nowTime >= targetTime)
                {
                    nowTime = 0f;
                    trafficColor = LightColor.Orange;
                }
                ColorImage.color = Color.red;
                break;

            case LightColor.Orange:
                targetTime = _orangeTime;
                if (nowTime >= targetTime)
                {
                    nowTime = 0f;
                    trafficColor = LightColor.Green;
                }
                ColorImage.color = Color.yellow;
                break;

            case LightColor.Green:
                targetTime = _greenTime;
                if (nowTime >= targetTime)
                {
                    nowTime = 0f;
                    trafficColor = LightColor.Red;
                }
                ColorImage.color = Color.green;
                break;
        }

        ColorText.text = (targetTime - nowTime).ToString();
    }

}
