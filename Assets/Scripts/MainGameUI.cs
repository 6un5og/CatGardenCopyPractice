using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainGameUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public enum ItemType
    {
        Box, Coin, Potion, Sword
    }

    Transform canvas;
    Transform prevParent;
    RectTransform rect;
    Animator anim;
    CanvasGroup canvasGroup;

    public int itemLevel;
    public bool isMerge;

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

    void OnDisable()
    {
        itemLevel = 0;
        anim.SetInteger("BoxLevel", 0);
        anim.SetInteger("ItemLevel", 0);
        anim.SetBool("isCoin", false);
        anim.SetBool("isPotion", false);
        anim.SetBool("isSword", false);
    }

    public void LevelUp()
    {
        if (isMerge)
        {
            itemLevel += 1;
            anim.SetInteger("ItemLevel", itemLevel);

        }
        // switch (switch_on)
        // {
        //     case ItemType.Coin:
        //         anim.SetBool("isCoin", true);
        //         break;
        //     case ItemType.Potion:
        //         anim.SetBool("isPotion", true);
        //         break;
        //     case ItemType.Sword:
        //         anim.SetBool("isSword", true);
        //         break;
        // }
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
            transform.localScale = Vector3.zero;
        }
    }
}
