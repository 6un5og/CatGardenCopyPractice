using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    Animator anim;
    GameObject slotParent => GameManager.instance.slotParent;
    GameObject item => GameManager.instance.item;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        anim.SetInteger("Level", 0);
    }

    public void CreateClick()
    {
        anim.SetTrigger("click");
        NewItem();
    }

    GameObject NewItem()
    {
        GameObject select = null;
        for (int index = 0; index < GameManager.instance.gameSlotCount; index++)
        {
            if (slotParent.transform.GetChild(index).childCount == 0)
                return Instantiate(item, slotParent.transform.GetChild(index));
            else if (slotParent.transform.GetChild(index).childCount != 0 && slotParent.transform.GetChild(index).Find("Box Item").gameObject.activeSelf == false)
                slotParent.transform.GetChild(index).Find("Box Item").gameObject.SetActive(true);
            else
                continue;
        }
        return select;
    }
}
