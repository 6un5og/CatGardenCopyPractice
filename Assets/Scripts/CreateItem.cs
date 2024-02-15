using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void CreateClick()
    {
        anim.SetTrigger("click");
        GameManager.instance.CreateNewSlot();
    }

    void OnEnable()
    {
        anim.SetInteger("Level", 0);
    }

}
