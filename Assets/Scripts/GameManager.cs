using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject slotParent;
    public GameObject slot;
    public GameObject item;

    public int poolCursor;

    List<GameObject>[,] slots = new List<GameObject>[8, 7];
    List<MainGameUI> items = new List<MainGameUI>();

    void Awake()
    {
        StartGame();
    }

    void StartGame()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                slots[i, j] = new List<GameObject>();
                GameObject gameSlot = Instantiate(slot, slotParent.transform);
                if (i >= 3 && i <= 5 && j >= 2 && j <= 4)
                    continue;
                Instantiate(item, gameSlot.transform);
            }
        }
    }

    MainGameUI MakeItem(GameSlot gameSlot)
    {
        GameObject instantItemObj = Instantiate(item, gameSlot.transform);
        MainGameUI instantItem = instantItemObj.GetComponent<MainGameUI>();
        items.Add(instantItem);
        return instantItem;
    }

    public MainGameUI CreateNewSlot()
    {
        for (int index = 0; index < slotParent.transform.childCount; index++)
        {
            if (slotParent.transform.GetChild(index).childCount == 0)
            {
                return slotParent.transform.GetChild(index).transform.GetComponent<MainGameUI>();
            }
            else
            {
                for (int i = 0; i < slotParent.transform.GetChild(index).childCount; i++)
                {
                    if (!slotParent.transform.GetChild(index).GetChild(i).gameObject.activeSelf)
                    {
                        return slotParent.transform.GetChild(index).GetChild(i).GetComponent<MainGameUI>();
                    }
                    else
                        break;
                }

            }
        }
        return MakeItem(slot.GetComponent<GameSlot>());
    }
}


