using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreater : MonoBehaviour
{
    // 목표 :
    // 씬에 구오브젝트(sprite)를 Q버튼을 누를때마다 생성하기
    // 만약 5개 이상 생성시 제일 먼저 만들어진 오브젝트를 파괴

    // 구현방법 :
    // 프리팹을 이용해서
    // Q버튼을 누를때마다 오브젝트를 생성하고 (GameObject.Instantiate)
    // 오브젝트를 생성할 때마다 리스트에 등록 List<GameObject> => 0
    // 생성된

    public List<GameObject> ObjList = new List<GameObject>();
    public GameObject Prefab;
    public int maxspawnCount = 7;

    void Create()
    {
        GameObject newOne;

        if (ObjList.Count < +maxspawnCount)
        {
            newOne = GameObject.Instantiate(Prefab);
        }
        else
        {
            newOne = ObjList[0];
            ObjList.Remove(ObjList[0]);
        }

        ChangeColor(newOne);
        newOne.GetComponentInChildren<ParticleSystem>().Play();

        ObjList.Add(newOne);
    }

    private void ChangeColor(GameObject go)
    {
        Color[] colors = { Color.cyan, Color.green, Color.red, Color.black, Color.yellow };
        go.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Create();
        }

    }
}
