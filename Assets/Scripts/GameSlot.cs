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
        if (eventData.pointerDrag.CompareTag("Box"))
        {
            if (transform.childCount == 0)
            {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            }
            else
            {
                //eventData.pointerDrag.transform.SetParent(transform);
                //eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
                //transform.SetParent(eventData.pointerDrag.GetComponent<MainGameUI>().prevParent.transform);
                //rect.position = eventData.pointerDrag.GetComponent<MainGameUI>().prevParent.transform.GetComponent<RectTransform>().position;
                Debug.Log("비어있지 않습니다");

            }

        }
    }
}
