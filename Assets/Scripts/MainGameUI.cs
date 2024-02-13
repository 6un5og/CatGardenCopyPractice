using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainGameUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Transform canvas;
    public Transform prevParent;
    RectTransform rect;
    Animator anim;
    CanvasGroup canvasGroup;

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void OnEnable()
    {
        anim.SetInteger("BoxLevel", 1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.CompareTag("Box"))
        {
            prevParent = transform.parent;

            transform.SetParent(canvas);
            transform.SetAsLastSibling();

            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
        else
            Debug.Log("비어있는 슬롯입니다.");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.CompareTag("Box"))
            rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.CompareTag("Box"))
        {
            if (transform.parent == canvas)
            {
                transform.SetParent(prevParent);
                rect.position = prevParent.GetComponent<RectTransform>().position;
            }

            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.tag == transform.tag)
        {
            eventData.pointerDrag.transform.SetParent(transform.parent);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;

            transform.SetParent(eventData.pointerDrag.GetComponent<MainGameUI>().prevParent);
            rect.position = eventData.pointerDrag.GetComponent<MainGameUI>().prevParent.GetComponent<RectTransform>().position;
            transform.gameObject.SetActive(false);
        }
    }
}
