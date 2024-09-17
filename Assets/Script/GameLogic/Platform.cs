using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Vector3 moveDirection = Vector3.left;
    public float EndPoint = -10;

    public Vector3 InitialPosition;

    public GameObject Coin1;
    public GameObject Coin2;
    public GameObject Coin3;
    public GameObject[] Coins;

    public GameObject Obstacle1;
    public GameObject Obstacle2;
    public GameObject Obstacle3;
    public GameObject[] Obstacles;

    public GameObject SpeedItem;
    public GameObject ScaleItem;
    public GameObject HealthItem;
    public GameObject[] Items;

    private void ActivateAllCoins()
    {
        foreach (var coin in Coins)
        {
            foreach (Transform child in coin.transform)
            {
                child.GetComponent<Coin>().OnDisable();
                child.gameObject.SetActive(true);
            }
        }
    }

    private void ActivateAllObstacles()
    {
        foreach (var obstacle in Obstacles)
        {
            foreach (Transform child in obstacle.transform)
            {
                child.GetComponent<Obstacles>().OnDisable();
                child.gameObject.SetActive(true);
            }
        }
    }

    private void ActivateAllItems()
    {
        foreach (var Item in Items)
        {
            foreach (Transform child in Item.transform)
            {
                child.GetComponent<Items>().OnDisable();
                child.gameObject.SetActive(true);
            }
        }
    }

    public void Init()
    {
        ActivateAllCoins();
        ActivateAllObstacles();
        ActivateAllItems();

        transform.position = InitialPosition;
        this.gameObject.SetActive(true);
        SpawnCoinWithWeightRandom();
        SpawnObstaclesWithWeightRandom();
        SpawnItemsWithWeightRandom();
    }
    private void Awake()
    {
        InitialPosition = transform.position;
        InitialPosition.x = PlatformSpawner.initial_x;
        Coins = new GameObject[] { Coin1, Coin2, Coin3 };
        Obstacles = new GameObject[] { Obstacle1, Obstacle2, Obstacle3 };
        Items = new GameObject[] { SpeedItem, ScaleItem, HealthItem };
        SpawnCoinWithWeightRandom();
        SpawnObstaclesWithWeightRandom();
        SpawnItemsWithWeightRandom();
    }

    void Update()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }

        if (!GameManager.Instance.IsGameOver)
        {
            if (!GameManager.Instance.IsPause)
            {
                moveSpeed = GameManager.Instance.GameSpeed;

                if (GameManager.Instance.SpeedEffectTime >= 0)
                {
                    moveSpeed = moveSpeed * 1.5f;
                }

                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

                if (transform.position.x < EndPoint)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }

    }

    private void SpawnCoin()
    {
        // 1. 모든 코인을 비활성화
        // 1. Coin1 비활성화, Coin2 비활성화, Coin3 비활성화
        // 2. 랜덤으로 한 코인만 활성화

        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        Coin3.gameObject.SetActive(false);

        int randomIndex = Random.Range(1, 4);
        // 1 2 3
        if (randomIndex == 1)
        {
            Coin1.gameObject.SetActive(true);
        }
        else if (randomIndex == 2)
        {
            Coin2.gameObject.SetActive(true);
        }
        else
        {
            Coin3.gameObject.SetActive(true);
        }
    }

    private void SpawnCoinReNew()
    {
        for (int i = 0; i < Coins.Length; i++)
        {
            Coins[i].gameObject.SetActive(false);
        }

        int randomIndex = Random.Range(0, Coins.Length);

        Coins[randomIndex].gameObject.SetActive(true);
    }

    private void SpawnCoinWithWeightRandom()
    {
        for (int i = 0; i < Coins.Length; i++)
        {
            Coins[i].gameObject.SetActive(false);
        }

        GameObject target = Coins[0];

        // coin1 coin2 coin3
        int[] weights = new int[] { 20, 30, 50 };

        int totalWeight = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            totalWeight += weights[i];
        }

        int randomIndex = Random.Range(0, totalWeight);
        for (int i = 0; i < weights.Length; i++)
        {
            if (randomIndex < weights[i])
            {
                target = Coins[i];
                break;
            }

            randomIndex -= weights[i];
        }

        target.SetActive(true);
    }

    private void SpawnObstaclesWithWeightRandom()
    {
        for (int i = 0; i < Obstacles.Length; i++)
        {
            Obstacles[i].gameObject.SetActive(false);
        }

        GameObject target = null;

        // coin1 coin2 coin3
        int[] weights = new int[] { 20, 30, 50, 100 };

        int totalWeight = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            totalWeight += weights[i];
        }

        int randomIndex = Random.Range(0, totalWeight);
        for (int i = 0; i < weights.Length; i++)
        {
            if (randomIndex < weights[i])
            {
                if (i < Obstacles.Length)
                {
                    target = Obstacles[i];
                }
                break;
            }

            randomIndex -= weights[i];
        }

        if (target != null)
        {
            target.SetActive(true);
        }
    }

    private void SpawnItemsWithWeightRandom()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].gameObject.SetActive(false);
        }

        GameObject target = null;

        // coin1 coin2 coin3
        int[] weights = new int[] { 20, 30, 50, 100 };

        int totalWeight = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            totalWeight += weights[i];
        }

        int randomIndex = Random.Range(0, totalWeight);
        for (int i = 0; i < weights.Length; i++)
        {
            if (randomIndex < weights[i])
            {
                if (i < Items.Length)
                {
                    target = Items[i];
                }
                break;
            }

            randomIndex -= weights[i];
        }

        if (target != null)
        {
            target.SetActive(true);
        }
    }
}