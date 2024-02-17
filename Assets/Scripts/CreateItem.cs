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
            Debug.Log("슬롯 도는중");
            if (slotParent.transform.GetChild(index).childCount != 0)
            {
                for (int i = 0; i < slotParent.transform.GetChild(index).childCount; i++)
                {
                    if (!slotParent.transform.GetChild(index).GetChild(i).gameObject.activeSelf)
                    {
                        slotParent.transform.GetChild(index).GetChild(i).gameObject.SetActive(true);
                    }
                    else
                        break;
                }
            }
            else
                return Instantiate(item, slotParent.transform.GetChild(index));
        }
        return select;
    }
}
