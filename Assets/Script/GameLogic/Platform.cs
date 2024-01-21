using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Vector3 moveDirection = Vector3.left;
    public float EndPoint = -10;

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (transform.position.x < EndPoint)
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = Vector3.zero + Vector3.right * 20f;
            this.gameObject.SetActive(true);
        }
    }
}
