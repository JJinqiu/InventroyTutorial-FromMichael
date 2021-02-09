﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotCount;

    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInformation(slotItem.itemInfo);
    }
}
