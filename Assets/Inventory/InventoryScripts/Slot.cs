﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotCount;
    public string slotInfo;
    public int slotID; // 空格ID等于物品ID
    
    public GameObject itemInSlot;
    
    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInformation(slotInfo);
    }

    public void SetupSlot(Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;
        slotCount.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }
}
