using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailBoxManager : MonoBehaviour
{
    public Button MailBoxButton; // 인스펙터에서 할당할 우체통 버튼
    public GameObject letterPrefab; // 인스펙터에서 할당할, 생성할 프리팹
    public List<string> LetterText; // 편지내용

    void Start()
    {
        AddLetterText();

        MailBoxButton.onClick.AddListener(OpenLetter);
    }

    // Update is called once per frame
    private void OpenLetter()
    {
        int randomIndex = Random.Range(0, LetterText.Count);

        // 프리팹 + 리스너 패턴
        GameObject letter = Instantiate(letterPrefab);
        letter.transform.parent = this.transform;
        letter.transform.localPosition = Vector3.zero;
        letter.GetComponentInChildren<Text>().text = LetterText[randomIndex];
        letter.GetComponent<Button>().onClick.AddListener(() => Destroy(letter));
    }

    private void AddLetterText()
    {
        LetterText = new List<string>();
        LetterText.Add("친구야! 오늘은 너의 00번째 생일이구나!");
        LetterText.Add("너와 함께한 모든 순간이 행복하고 소중한 추억이야 네가 얼마나 특별한 친구인지");
        LetterText.Add("말로 다 표현할 수 없어 오늘은 네가 가장 행복했으면 좋겠다");
        LetterText.Add("앞으로도 함께 많은 이야기를 나누고");
        LetterText.Add("즐거운 일들로 가득한 시간을 보내자!");
    }

    // 1. List
    // 리스트는 데이터를 순서대로 저장합니다.
    // 배열이랑 같은거 아닌가? =>
    // int[] a = int[5] => 5 6 7 8
    // List<int> a = add / remove
    // 1 2 3 4 5 => -2 => 1 3 4 5
    // 출석부 => List
    // 배열 => 철도 => = =ㅌ= ====
    // [사용법] add / remove

    // 2. Stack
    // LIFO : Last in First Out
    // 교과서를 6권을 순서대로 쌓았다 => 마지막에 들어온 책부처 꺼낸다.
    // Stack<int> stack = new Stack<int>();
    // Push / Pop
    // Stack.Push(1);
    // Stack.Push(2);
    // Stack.Push(3);
    // int c = Stack.Pop();

    // 3. Queue
    // FIFO : First in First Out
    // 음식, 놀이공원 줄
    // 음식 = 유통기한
    // 음식 = 오래된 음식부터 먹는다
    // 놀이공원 = 줄을 선 순서대로 입장
    // Queue<string> queue = new Queue<string>();
    // Enqueue / Dequeue
    // queue.Enqueue ("First");
    // queue.Enqueue ("Second");
    // queue.Enqueue ("Third");
    // string c = queue.Dequeue();

}
