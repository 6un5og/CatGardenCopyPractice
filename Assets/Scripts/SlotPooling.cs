using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPooling : MonoBehaviour
{
    public GameObject slotPool;

    List<GameObject>[,] slots = new List<GameObject>[7, 8];

    void Awake()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                slots[i, j] = new List<GameObject>();
                Instantiate(slotPool, transform);
            }
        }
    }
}