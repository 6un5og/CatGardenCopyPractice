using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameSlotUI : MonoBehaviour, IDropHandler
{
    RectTransform rect;
    public GameObject[] itemIcon;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void Start()
    {
        GameObject ranIcon = itemIcon[Random.Range(0, 2)];
        Instantiate(ranIcon, transform);
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
