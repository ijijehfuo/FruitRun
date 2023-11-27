using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelect : MonoBehaviour
{
    public Button LeftButton;
    public Button RightButton;

    public Character[] Characters;
    public GameObject ButtonPrefab;
    public Transform ButtonParent;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _descriptionText;
    [SerializeField] private Animator _animator;
    private int _currentIndex = 0;

    void Start()
    {
        UpdateCharacterDisplay();
        AddEvent();
    }

    private void AddEvent()
    {
        LeftButton.onClick.AddListener(PreviousCharacter);
        RightButton.onClick.AddListener(NextCharacter);
    }

    private void UpdateCharacterDisplay()
    {
        Character currentCharacter = Characters[_currentIndex];
        _nameText.text = currentCharacter.Name;
        _descriptionText.text = currentCharacter.Description;
        _animator.runtimeAnimatorController = currentCharacter.Animator;
        LoadSkill(currentCharacter);
    }

    private void LoadSkill(Character currentCharacter)
    {
        for (int i = 0; i < ButtonParent.childCount; i++)
        {
            Destroy(ButtonParent.GetChild(i));
        }

        for (int i = 0; i < currentCharacter.Skills.Length; i++)
        {
            GameObject Button = GameObject.Instantiate(ButtonPrefab, ButtonParent);
            Button.GetComponent<SkillButton>().Skill = currentCharacter.Skills[i];
            Button.GetComponent<SkillButton>().Button.onClick.AddListener(() => UISkillPopup.Instance.SetData(Button.GetComponent<SkillButton>().Skill));
            Button.GetComponent<SkillButton>().Button.onClick.AddListener(() => UISkillPopup.Instance.Open());

        }
    }

    private void NextCharacter()
    {
        _currentIndex = (_currentIndex + 1) % Characters.Length;
        UpdateCharacterDisplay();
    }

    private void PreviousCharacter()
    {
        _currentIndex = (_currentIndex + Characters.Length - 1) % Characters.Length;
        UpdateCharacterDisplay();
    }

    // UI 업데이트 개념 => (사과, 바나나, 수박, 멜론)
    // 사과 체이지 (사과이름, 사과에 대한 설명, 달다 표현)
    // 다음 과일보기 => 과일들[0] = 사과 => 과일들[1] = 바나나
    // 과일 : 바나나
    // 바나나 페이지 (바나나 이, 바나나에 대한 설, 바나나 달다 표현)

    // AddEvent => 동전을 넣는행위 Action => 분류 => 100 500 => LED금액을 띄움
    //                                       => 돈이 X => 반환

    // 버튼에 대한 핵심로직!!
    // 1번 컵라면, 2번 과자, 3번이 초콜릿
    // < [1] >
    // next = current + 1
    // 1, 2, 3, 4...
    // previous = current - 1
    // 3, 2, 1, -1...

    // 무조건 1,2,3 만 나오도록 해야함
    // (3 + 1) / 3 = 1 + 0 = 1
    // (3 + 1) % 3 = 0 + 1 = 1
    // (1 - 1) % 3 = 1 - 1 = 0 => 3번
    // (1 + 3 - 1 - 1) % 3 = 1 + 0 - 1 - 1 = |-1|
}