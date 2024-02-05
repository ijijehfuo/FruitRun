using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Vector3 moveDirection = Vector3.left;
    public float EndPoint = -20;

    public Vector3 initialPosition;

    public void init()
    {
        transform.position = initialPosition;
        this.gameObject.SetActive(true);
    }

    private void Awake()
    {
        initialPosition = transform.position;
        init();
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
}
