﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInformation;

    private void Awake()
    {
        if (_instance != null)
            Destroy(this);
        _instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        _instance.itemInformation.text = "";
    }

    public static void UpdateItemInformation(string itemDescription)
    {
        _instance.itemInformation.text = itemDescription;
    }
    
    private static void CreateNewItem(Item item)
    {
        var newItem = Instantiate(_instance.slotPrefab, _instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(_instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotCount.text = item.itemHeld.ToString();
    }

    public static void RefreshItem()
    {
        for (var i = 0; i < _instance.slotGrid.transform.childCount; ++i)
        {
            if (_instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(_instance.slotGrid.transform.GetChild(i).gameObject);
        }

        foreach (var item in _instance.myBag.itemList)
        {
            CreateNewItem(item);
        }
    }
}