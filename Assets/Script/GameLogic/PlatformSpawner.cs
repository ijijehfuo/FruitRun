using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // 역할:
    // 1. 플랫폼을 생성하는 일을 한다
    // 2. 플랫폼을 생성 시 y축 랜덤으로 배치
    // 3. * 일정 개수 이상 중가하면 더이상 생성하지 않고 재활용한다

    // 1. 구현방향
    // 생성을 하기위한 프리팹을 만들고 선언한다

    // 2.

    // 4. 3초에 하나씩 플랫폼을 생성
    //

    public GameObject Prefab;
    public List<GameObject> Platforms = new();
    public float SpawnTime = 2f;
    public static float initial_x = 18f;
    private float Max_Y = 5f;
    private float Min_Y = -3f;
    private float currentTime = 0f;

    private void Create()
    {
        GameObject go = GameObject.Instantiate(Prefab);
        Platforms.Add(go);

        go.transform.position = Vector3.right * initial_x;
        go.transform.position += Vector3.up * Random.Range(Min_Y, Max_Y);
    }

    private void Recycle()
    {
        for (int i = 0; i <Platforms.Count; i++)
        {
            if (!Platforms[i].gameObject.activeSelf)
            {
                Platforms[i].GetComponent<Platform>().init();
                Platforms[i].transform.position += Vector3.up * Random.Range(Min_Y, Max_Y);

                break;
            }
        }
    }

    private void Update()
    {
        // 게임속도에 따라 spawnTime 조정
        float adjustedSpawnTime = Mathf.Max(SpawnTime - GameManager.Instance.GameSpeed * 0.1f, 1f);

        currentTime += Time.deltaTime;
        if (currentTime >= adjustedSpawnTime)
        {
            if (Platforms.Count >= 10)
            {
                Recycle();
            }
            else
            {
                Create();
            }
            currentTime = 0f;
        }
    }
}
