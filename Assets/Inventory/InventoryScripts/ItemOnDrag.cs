using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public Inventory myBag;
    public int currentItemID; // 当前物品id

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // 记录父级
        currentItemID = originalParent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        // Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Item Image")
        {
            var temp = myBag.itemList[currentItemID];
            myBag.itemList[currentItemID] =
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
            myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] =
                myBag.itemList[currentItemID];
            myBag.itemList[currentItemID] = null;
        }
        else
        {
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}