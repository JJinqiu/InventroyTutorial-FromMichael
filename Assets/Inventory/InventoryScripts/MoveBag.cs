using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBag : MonoBehaviour, IDragHandler
{
    private RectTransform _currentRect;

    private void Awake()
    {
        _currentRect = GetComponent<RectTransform>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        _currentRect.anchoredPosition += eventData.delta;
    }
}
