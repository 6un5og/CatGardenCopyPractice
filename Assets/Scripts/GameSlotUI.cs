using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameSlotUI : MonoBehaviour, IDropHandler
{
    Image image;
    RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
    }
}
