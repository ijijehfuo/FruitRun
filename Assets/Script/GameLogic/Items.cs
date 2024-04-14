using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Health = 0,
    Speed = 1,
    Scale = 2,
}

public class Items : MonoBehaviour
{
    private bool isRotate;
    private float timer = 0;
    public ItemType type = ItemType.Health;

    public void OnEarned()
    {
        if (isRotate == true)
        {
            return;
        }
        isRotate = true;

        audioManager.Instance.PlayEffect(ClipName.Food);

        if (type == ItemType.Health)
        {
            GameManager.Instance.IncreaseHealth(15);
        }
        else if (type == ItemType.Speed)
        {
            GameManager.Instance.IncreaseSpeedTime(5);
        }
        else if (type == ItemType.Scale)
        {

        }
        
    }

    public void OnDisable()
    {
        isRotate = false;
        timer = 0;
        transform.rotation = Quaternion.identity;
    }

    public void Update()
    {

        if (isRotate)
        {
            gameObject.transform.Rotate(Vector3.up * 10f);
            // 2초간 회전이후 오브젝트 비활성화
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                isRotate = false;
                gameObject.SetActive(false);
                timer = 0;
                gameObject.transform.Rotate(0, 0, 0);
            }
        }
    }
}
