using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTypes : MonoBehaviour
{
    // 자료형!
    // int / string / float / char / double / short / long / longlong / byte

    // 문자를 나타내기 위한 최초의 자료형
    // char (문자형) - 알파벳 블록
    // 예를 들어 'A', 'B', 'C' 한 글자를 표현
    char letter_A = 'A';
    char letter_P = 'P'; // 불편하다

    // string (문자열형) - 단어 또는 문장 
    // 불편했던 점 보완, 여러 알파벳 블록이 이어진 것과 같다.
    // 여기에 사용된 개념은 배열 => 리스트 / 배열
    // 더큰 아차트 더큰 배열 쇠사슬 => 원형 고리를 이으면 무한대로 늘어남
    // 아파트 => 물리적 제한 수용가능한 인원 이상이면 새로운 아파트 분양
    string word = "Hello";
    // char[] sen = { 'a', 'b', 'c', 'd', 'e'};

    // 3. int (정수형) - 계산기의 숫자
    // 계산기에 입력하는 숫자는 소수점이 아예 없다. => 덧셈이다 뻴셈둥의 계산에 주로 사용
    int age = 13;

    // 4. float 와 double (부동 소수점형) - 측정컵
    // 물이나 가루를 정확하게 계량컵과 같다. => 길이나 무게를 정밀하게 표현하기 위해 사용
    float height = 1.6f; // 바뀌는 수를 정할 때 사용
    double weight = 45.5; // 정해 놓고 사용 할 때 사용 (요즘에는 많이 안씀)

    // 5. short (정수형) - 계산기의 숫자 / long (큰 정수형) - 공학용 계산기 / 0-255 (256) 컬러 색깔 1 + 1 + 1 = 3바이트
    short smallNumber = 1000;

    // Casting

    // 1. double => float으로의 변환 = 정교한 줄자에서 덜 정교한 줄자로 변환!
    // double 더 많은 세부사항을 담을 수 있다, float 세부사항을 덜 담을 수 있다

    // 2. float => int으로의 변환 - 자를 사용하다가 이제 손으로 어림짐작
    // float는 소수점을 포함한 정밀한 수치를 가지지만, int 변환시에 소수점 아래부분을 잃어버린다.

    private void Start()
    {
        CastingTest();
    }

    private void CastingTest()
    {
        double longPi = 3.141592653589793238; // 긴 줄자
        float shortPi = (float)longPi; // 짧은 줄자

        Debug.Log("데이빗 : 파이를 long값으로 보여줘");
        Debug.Log(longPi);
        Debug.Log("데이빗 : 파이를 float값으로 보여줘");
        Debug.Log(shortPi);

        float height = 1.75f; // 정밀측정값
        int integerHeight = (int)height; // 대략적 측정으로 변환
        Debug.Log("데이빗 : 내 키를 자세하게 보여줘");
        Debug.Log(height);
        Debug.Log("데이빗 : 내 키를 대략적으로 보여줘");
        Debug.Log(integerHeight);

    }

    private void AnnaTest()
    {
        // 문자열
        Debug.Log("안나 : A랑 l을 나에게 보여줘!");
        Debug.Log(letter_A);
        Debug.Log(word[2]);

        Debug.Log("안나 : 내 키는 1.7미터애 나의 키를 표현해줘");
        Debug.Log(height + 0.1f);
        double AnnaHeight = 1.7;
        Debug.Log(AnnaHeight);

        string string_A = "A";
        int number_A = letter_A;
        char letter_B = (char)(number_A + 1);


        char letter_D = 'D';
        int number_D = letter_D;
        Debug.Log("안나 : D의 아스키코드값을 알려줘");
        Debug.Log(number_D);
        Debug.Log(number_A + 3);

        Debug.Log("안나 : D의 아스키코드를 다시 알파벳으로 보여줘!");
        Debug.Log((char)number_D);
    }
}
