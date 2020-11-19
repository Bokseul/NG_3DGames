using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelOption : MonoBehaviour, IPointerDownHandler
{
    private bool RoyalShop_ck;

    private GameObject Inventory;
    private GameObject Quest;
    private GameObject RoyalShop;

    private void Awake()
    {
        Inventory = GameObject.Find("Op_Inventory");
        Quest = GameObject.Find("Op_Quest");
        RoyalShop = GameObject.Find("Op_RoyalShop");
    }

    private void Open_Inventory()
    {

    }

    private void Open_Quest()
    {

    }

    private void Open_RoyalShop()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Inventory)
            Open_Inventory();
        else if (Quest)
            Open_Quest();
        else if (RoyalShop)
            Open_RoyalShop();
    }
}
