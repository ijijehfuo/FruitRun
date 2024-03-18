using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamShop
{
    public int Price = 3000;

    public void SelectIceCream(string flavor)
    {
        if (flavor == "Chocolate")
        {
            Debug.Log("You Selected Chocolate flavor");
            return;
        }

        if (flavor == "Vanilla")
        {
            Debug.Log("You Selected Vanilla flavor");
            return;
        }
    }

    public char ch()
    {
        return 'C';
    }

    public string GetSeller()
    {
        return "Alex";
    }

    public int tips()
    {
        return 500;
    }

    public void tipps()
    {
        return;
    }

    public GameObject Go()
    {
        return new GameObject(); 
    }
}


public class ReturnController : MonoBehaviour
{
    IceCreamShop B31 = new IceCreamShop();

    void Start()
    {
        B31.SelectIceCream("");
        Debug.Log(B31.GetSeller());

        // 예상
        // Alex
    }


    void Update()
    {
        
    }
}
