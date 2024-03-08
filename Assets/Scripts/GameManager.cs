using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject slotParent;
    public GameObject slot;
    public GameObject item;
    public GameObject effectPrefab;

    public int poolCursor;
    public int gameSlotCount;
    List<GameObject>[,] slots = new List<GameObject>[8, 7];

    public Text itemLevel;
    public Text itemName;

    void Awake()
    {
        instance = this;
        StartGame();
        gameSlotCount = slots.Length;
        Instantiate(effectPrefab);
    }

    void StartGame()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                slots[i, j] = new List<GameObject>();
                GameObject gameSlot = Instantiate(slot, slotParent.transform);
                if (i >= 2 && i <= 5 && j >= 2 && j <= 4)
                    continue;
                // GameObject boxItem = Instantiate(item, gameSlot.transform);
                // boxItem.GetComponent<MainGameUI>().level = Random.Range(3, 5);
                // boxItem.GetComponent<Animator>().SetInteger("Level", 0);
            }
        }
    }
}