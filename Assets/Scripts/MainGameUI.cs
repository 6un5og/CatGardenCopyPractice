using UnityEngine;
using UnityEngine.EventSystems;

public class MainGameUI : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public enum ItemType { Box, Coin, Potion, Sword }

    Transform canvas;
    public Transform prevParent;
    RectTransform rect;
    Animator anim;
    CanvasGroup canvasGroup;

    public ParticleSystem effect;
    public int level;

    public ItemType ItemTypes { get; set; }

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public ItemType GetRandomEnumValue()
    {
        var enumValue = System.Enum.GetValues(enumType: typeof(ItemType));
        return (ItemType)enumValue.GetValue(Random.Range(1, enumValue.Length));
    }

    void OnEnable()
    {
        ItemTypes = GetRandomEnumValue();
        switch (ItemTypes)
        {
            case ItemType.Coin:
                anim.SetBool("isCoin", true);
                break;
            case ItemType.Potion:
                anim.SetBool("isPotion", true);
                break;
            case ItemType.Sword:
                anim.SetBool("isSword", true);
                break;
        }
    }

    void OnDisable()
    {
        level = 0;
        anim.SetInteger("Level", 0);
        anim.SetBool("isCoin", false);
        anim.SetBool("isPotion", false);
        anim.SetBool("isSword", false);
    }

    public void LevelUp()
    {
        anim.SetInteger("Level", ++level);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MainGameUI dragInfo = eventData.pointerClick.GetComponent<MainGameUI>();
        GameManager.instance.itemName.text = dragInfo.ItemTypes.ToString() + "\nLv. " + dragInfo.level.ToString();
        GameManager.instance.itemInfo.text = dragInfo.level.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        MainGameUI dragInfo = eventData.pointerClick.GetComponent<MainGameUI>();
        GameManager.instance.itemName.text = dragInfo.ItemTypes.ToString() + "\nLv. " + dragInfo.level.ToString();
        GameManager.instance.itemInfo.text = dragInfo.level.ToString();

        if (eventData.pointerDrag.CompareTag("Box"))
        {
            prevParent = transform.parent;

            transform.SetParent(canvas);
            transform.SetAsLastSibling();

            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
        else return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag.CompareTag("Box"))
            rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        MainGameUI dragInfo = eventData.pointerDrag.GetComponent<MainGameUI>();
        GameManager.instance.itemName.text = dragInfo.ItemTypes.ToString() + "\nLv. " + dragInfo.level.ToString();
        GameManager.instance.itemInfo.text = dragInfo.level.ToString();

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
        GameObject dragItem = eventData.pointerDrag;
        MainGameUI dragItemUI = dragItem.transform.GetComponent<MainGameUI>();
        MainGameUI thisItemUI = transform.GetComponent<MainGameUI>();

        if (dragItemUI != null && dragItemUI.ItemTypes == thisItemUI.ItemTypes && dragItemUI.level == thisItemUI.level)
        {
            dragItem.transform.SetParent(transform.parent);
            dragItem.GetComponent<RectTransform>().position = rect.position;
            dragItemUI.LevelUp();

            effect.transform.position = dragItem.transform.position;
            effect.transform.localScale = dragItem.transform.localScale;
            effect.Play();

            transform.gameObject.SetActive(false);
            transform.localScale = Vector3.zero;
        }
        else return;
    }
}