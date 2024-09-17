using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private bool isRotate;
    private float timer = 0;
    public ParticleSystem particle;

    public void OnEarned()
    {
        particle.Play();
        if (isRotate == true)
        {
            return;
        }

        isRotate = true;
        audioManager.Instance.PlayEffect(ClipName.Explo);
        CameraManager.instance.TriggerShake();
        GameManager.Instance.DecreaseHelath(2);
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
