using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 : 어디서든 이 클래스에 접근할 수 있다, 매번 만들지 않는다
    public static GameManager Instance { get; private set; }

    // 게임 생태 관리
    public bool IsGameStarted { get; private set; }
    public bool IsGameOver { get; private set; }

    // 게임 진행에 따른 변수들
    public int Score { get; private set; }
    public float GameSpeed { get; set; }
    public float PlayerHP { get; set; }

    // 특별 이벤트
    public bool IsSpeedBoostActive { get; private set; }
    public float SpeedBoostDuration = 5f;

    // 난이도 조절을 위한 시간 추적
    private float difficultyTimer;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        initializeGame();
    }

    void Update()
    {
        UpdateGameDifficulty();
    }

    private void initializeGame()
    {
        IsGameStarted = true;
        IsGameOver = false;
        Score = 0;
        PlayerHP = 10;
        GameSpeed = 3f;
        IsSpeedBoostActive = false;
        difficultyTimer = 0f;
    }

    private void UpdateGameDifficulty()
    {
        // difficultyTimer에 시간이 지나는것을 체크하고
        // 30초보다 크거나 같게 되었을때 게임속도 Gamespeed가 증가

        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= 5)
        {
            GameSpeed += 1f;
            difficultyTimer = 0;
        }
    }
}
