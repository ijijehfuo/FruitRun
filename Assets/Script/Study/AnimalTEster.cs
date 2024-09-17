using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 추상클래스
// 레시피

// 레시피
// 음식을 만드는 방법을 알려줍니다. 레시피 자체론 음식을 먹을 순 없다.
// 예를 들면 케이크 레시피는 케이크를 만들어주는 방법을 알려주지만, 레시피 만으로는 케이크를 만들 수 없다.
// 추상클래스는 메서드의 '선언' 방범을 제공하지만 그 자체로는 객체를 생성 할 수 없다.

// 구레적인 음식
// 딸기케이크, 초콜릿케이크는 레시피는 바탕으로 실제로 만들어 질 수 있다.
// 케이크 레세피라는 추상클래스에서 파생되서 만들어진 구체적인 클래스다.
// 케이크 레시피가 있었기 때문데 만들어 질 수 있었다.
// 구현이라는 방범이 있다.

// 레시피의 필수단계
// 반죽하기, 오븐에 굽기, => 필수단계
// 이런 단계들은 케이크들마다 순서가 다를수도 있고 조금씩 시간이 다를 수도 있다.
// 예를 들면 딸기케이크는 반죽에 딸기가 들어간다
// 초코케이크는 초콜릿이 들어간다.
// 추상메서드는 "반죽하기", "오븐에 굽기" 같은것들이다.
// 레시피 => 추상클래스는 가이드
// 물체를 만들기 위한 실제구현 => 추상클래스에서 파생된 클래스들(딸기케이크, 초콜릿케이크)에서 정해진다.

// 추상 클래스 정의

public abstract class Animal
{
    // 추상 메서드 정의
    public abstract void Speak();
}

public class Dog : Animal
{
    public override void Speak()
    {
        Debug.Log("Dog says : Woof!");
    }
}

public class Cat : Animal
{
    public override void Speak()
    {
        Debug.Log("Cat says: Meow!");
    }
}

public class AnimalTEster : MonoBehaviour
{
    private void Start()
    {
        // Dog와 Cat을 생성
        Animal myDog = new Dog();
        Animal myCat = new Cat();

        // Speak 메서드 추출
        myDog.Speak();
        myCat.Speak();
    }

}
