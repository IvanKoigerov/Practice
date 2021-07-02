using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chest : Interectable
{
    //public Item content;
    public bool isOpen;
    public Signals TakeItem;
    //public Inventory PlayerInventory;
    public BoolValue Open;

    public GameObject DiaObj;
    public Text DiaText;

    private Animator anim;

    void Start()
    {
        isOpen = Open.RunTimeValue;
        anim = GetComponent<Animator>();
        if (isOpen)
        {
            anim.SetBool("IsOpen", true);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InRange )
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestisOpen();
            }
        }
    }

    public void OpenChest()
    {
        DiaObj.SetActive(true);
        //DiaText.text = content.ItemName;
        //PlayerInventory.AddItem(content);
        //PlayerInventory.currentItem = content;
        TakeItem.Raise();
        isOpen = true;
        Open.RunTimeValue = isOpen;
        anim.SetBool("IsOpen", true);
        contextOff.Raise();

    }

    public void ChestisOpen()
    {

        isOpen = true;
        DiaObj.SetActive(false);

        TakeItem.Raise();
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            InRange = true;
            contextOn.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            InRange = false;

            contextOff.Raise();
        }
    }

}
