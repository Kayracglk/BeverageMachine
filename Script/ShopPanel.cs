using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Collider fanta;
    [SerializeField] private Collider meyveSuyu;
    [SerializeField] private int fantaCost;
    [SerializeField] private int meyveSuyuCost;

    public void FantaButton()
    {
        if(CashManager.instance.totalCash >= fantaCost)
        {
            fanta.enabled = true;
            Custemer.instance.beverageList.Add("Fanta");
            CashManager.instance.totalCash -= fantaCost;
        }
    }

    public void MeyveSuyuButton()
    {
        if (CashManager.instance.totalCash >= meyveSuyuCost)
        {
            meyveSuyu.enabled = true;
            Custemer.instance.beverageList.Add("MeyveSuyu");
            CashManager.instance.totalCash -= meyveSuyuCost;
        }
    }
}
