using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie
{
    private string name;
    private int health = 100;
    private int maxHealth = 100;
    private bool isDead = false;

    public int Damage
    {
        get { return health; }
        set
        {
            if (isDead)
            {
                return;
            }

            int damage = value;
            health -= damage;

            Debug.LogWarning(name + "에게 " + damage + " 데미지! ::::: " + health + " / " + maxHealth);

            if (health <= 0)
            {
                Debug.LogError(name + ": 이제 나의 체력이 다 닳았어!");
                isDead = true;
                health = 0;
            }
            else if (value > maxHealth)
            {
                health = maxHealth;
            }
        }
    }

    public int Heal
    {

        get { return health; }
        set
        {
            if (isDead)
            {
                return;
            }

            int heal = value;
            health += heal;

            Debug.Log(name + "에게 " + heal + " 회복! :::: " + health + " / " + maxHealth);

            if (health > maxHealth)
            {
                Debug.Log(name + ": 이제 나의 모든 체력이 다 회복되었어!");

                health = maxHealth;
            }
        }
    }

    public string Name
    {
        get
        {
            return name + "씨";
        }
        set
        {
            name = value;
        }
    }
}

public class PropertyStudy : MonoBehaviour
{
    // 프로퍼티라 C#에서 필드의 값을 읽거나 쓰는 메서드를 대신해서 사용하는 구분
    // 예 : 생명력, 하트아이템 획득시 생명력이 늘어난다

    private Cookie Co;
    private Cookie Go;
    private Cookie To;

    private GameObject Dummy0;
    private GameObject Dummy1;
    private GameObject Dummy2;
    private GameObject PrefabGo;


    void Start()
    {

        Co = new Cookie();
        Go = new Cookie();
        To = new Cookie();

        Co.Name = "코쿠키";
        Go.Name = "고쿠키";
        To.Name = "투쿠키";

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Co.Damage = Random.Range(0, 20);
            Go.Damage = Random.Range(0, 20);
            To.Damage = Random.Range(0, 20);

            Debug.Log("MathF MAX" + Mathf.Max(Go.Damage, Co.Damage, To.Damage));
            Debug.Log("MathF MIN" + Mathf.Min(Go.Damage, Co.Damage, To.Damage));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Co.Heal = Random.Range(0, 20);
            Go.Heal = Random.Range(0, 20);
            To.Heal = Random.Range(0, 20);
        }
    }
}
