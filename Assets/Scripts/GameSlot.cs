using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSlot : MonoBehaviour, IDropHandler
{
    RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragItem = eventData.pointerDrag;
        if (dragItem.CompareTag("Box"))
        {
            dragItem.transform.SetParent(transform);
            dragItem.GetComponent<RectTransform>().position = rect.position;
        }
        else return;
    }
}