using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTiler : MonoBehaviour
{
    public float scrollSpeed = 0.3f;
    private Vector2 offset = Vector2.zero;
    public Material material;

    void Start()
    {

    }

    void Update()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            offset.x += scrollSpeed * Time.deltaTime;
            material.mainTextureOffset = offset;
        }
    }
}
