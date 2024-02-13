using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject slotParent;
    public GameObject slot;
    public GameObject item;

    List<GameObject>[,] slots = new List<GameObject>[8, 7];

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

    public GameObject Get(int i, int j)
    {
        GameObject select = null;
        foreach (GameObject item in slots[i, j])
        {
            select = item;
            select.SetActive(true);
            break;
        }
        if (!select)
        {
            Debug.Log("공간이 없습니다.");
        }
        return select;
    }

    void NewItem()
    {

    }
}


