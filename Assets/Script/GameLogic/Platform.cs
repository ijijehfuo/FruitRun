using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Vector3 moveDirection = Vector3.left;
    public float EndPoint = -10;

    public Vector3 initialPosition;

    public GameObject Coin1;
    public GameObject Coin2;
    public GameObject Coin3;
    public GameObject[] Coins;

    public GameObject Obstacle1;
    public GameObject Obstacle2;
    public GameObject Obstacle3;
    public GameObject[] Obstacles;

    private void activateAllCoins()
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

    private void activateAllObstacles()
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
    public void init()
    {
        activateAllCoins();
        activateAllObstacles();
        transform.position = initialPosition;
        this.gameObject.SetActive(true);
        SpawnCoinWithWeightRandom();
        SpawnObstacleWithWeightRandom();
    }

    private void Awake()
    {
        initialPosition = transform.position;
        initialPosition.x = PlatformSpawner.initial_x;
        Coins = new GameObject[] { Coin1, Coin2, Coin3 };
        Obstacles = new GameObject[] { Obstacle1, Obstacle2, Obstacle3 };
        SpawnCoinWithWeightRandom();
        SpawnObstacleWithWeightRandom();
    }

    void Update()
    {
        if (!gameObject.activeSelf)
        {
            return;
        }
        moveSpeed = GameManager.Instance.GameSpeed;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (transform.position.x < EndPoint)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void SpawnCoin()
    {
        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        Coin3.gameObject.SetActive(false);

        int randomIndex = Random.Range(1,4);

        if (randomIndex == 1)
        {
            Coin1.gameObject.SetActive(true);
        }
        else if (randomIndex == 2)
        {
            Coin2.gameObject.SetActive(true);
        }
        else if (randomIndex == 3)
        {
            Coin3.gameObject.SetActive(true);
        }
    }

    private void SpawnCoinRenew()
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

    private void SpawnObstacleWithWeightRandom()
    {
        for (int i = 0; i < Obstacles.Length; i++)
        {
            Obstacles[i].gameObject.SetActive(false);
        }

        GameObject target = null;

        int[] weights = new int[] { 20, 30, 50, 100};

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
}
