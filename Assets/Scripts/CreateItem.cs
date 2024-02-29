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
        anim.SetInteger("Idle", 0);
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
            {
                GameObject newItem = Instantiate(item, slotParent.transform.GetChild(index));
                newItem.GetComponent<MainGameUI>().level = Random.Range(1, 3);
                newItem.GetComponent<Animator>().SetInteger("Level", newItem.GetComponent<MainGameUI>().level);

                return newItem;
            }
            else
                continue;
        }
        return select;
    }
}
