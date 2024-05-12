using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 : 어디서든 이클래스에 접근할수있다! 매번 만들지 않는다.
    public static GameManager Instance { get; private set; }

    // 게임 상태 관리
    public bool IsGameStarted { get; private set; }
    public bool IsGameOver { get; private set; }
    public bool IsPause { get; private set; }

    // 게임 진행에 따른 변수들
    public int Score { get; private set; }
    public float GameSpeed { get; set; }
    public float PlayerHP { get; set; }
    public int EarnedCoin { get; set; }

    // 특별 이벤트
    public bool IsScaleEventActive { get; set; }
    public bool IsSpeedBoostActive { get; private set; }
    public float SpeedBoostDuration = 5f;

    // 난이도 조절을 위한 시간 추적
    private float difficultyTimer;
    public float PlayTimeTimer = 0;

    // 체력 관련
    public float maxHp = 10;

    public float SpeedEffectTime = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (!IsGameOver)
        {
            if (!IsPause)
            {
                UpdateGameDifficulty();
                UpdatePlayTime();
                UpdateSpeedEffectTime();
            }
        }
    }

    private void InitializeGame()
    {
        IsGameStarted = true;
        IsGameOver = false;
        Score = 0;
        PlayerHP = maxHp;
        GameSpeed = 3f;
        IsSpeedBoostActive = false;
        difficultyTimer = 0f;
        PlayTimeTimer = 0f;
        EarnedCoin = 0;
    }

    public void GameOver()
    {
        if (IsGameOver == true)
        {
            return;
        }

        IsGameOver = true;
    }

    public void GamePause()
    {
        IsPause = true;
    }

    public void GameContinue()
    {
        IsPause = false;
    }

    public void LastScore(int score)
    {
        Score = score;
    }

    private void UpdateGameDifficulty()
    {
        // difficultyTimer로 시간이 지나는것을 체크하고
        // 30초보다 크거나 같게 되었을때 게임속도 gamespeed가 증가

        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= 30)
        {
            GameSpeed += 1f;
            difficultyTimer = 0;
        }
    }

    private void UpdatePlayTime()
    {
        if (IsPause)
        {
            return;
        }
        else
        {
            PlayTimeTimer += Time.deltaTime;
        }
    }

    private void UpdateSpeedEffectTime()
    {
        if (SpeedEffectTime >= 0)
        {
            SpeedEffectTime -= Time.deltaTime;
        }
    }

    public void IncreaseSpeedTime(int value)
    {
        SpeedEffectTime = value;
    }

    // 체력값을 매개변수로 받아
    // 체력을 높이는 코드

    // 최대체력 이상 시
    // 체력은 최대체력으로
    // 유지
    public void IncreaseHealth(int value)
    {
        PlayerHP += value;

        if (PlayerHP >= maxHp)
        {
            PlayerHP = maxHp;
        }
    }

    // 감소값을 매개변수로 받아
    // 체력을 낮추는 코드

    // 체력 0 이하일시에
    // IsGameOver를 참으로 설정
    public void DecreaseHelath(int value)
    {
        PlayerHP -= value;

        if (PlayerHP <= 0)
        {
            GameOver();
            PlayerHP = 0;
        }
    }
}