using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
    // protected void = 자신과 자식만 사용할 수 있음
    // override = 부모 것을 덮어씀 (수정함)
    // abstract = 조건부

    public Animator Animator;

    virtual protected void Onstart()
    {
        Animator.SetTrigger("Open");
    }


    virtual protected void Onclear()
    {
        Animator.SetTrigger("Close");
    }
}
