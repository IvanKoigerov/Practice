using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key, enemy, button
}

public class Door : Interectable
{

    public DoorType type;
    public bool open;
    //public Inventory PlayerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D colli2D;


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (InRange && type == DoorType.key)
            {
                //if (PlayerInventory.numberOfKeys > 0)
                //{
                //    PlayerInventory.numberOfKeys--;
                //    Open();
                //}
            }
        }
    }

    public void Open()
    {
        doorSprite.enabled = false;
        open = true;
        colli2D.enabled = false;
        this.gameObject.SetActive(false);
    }

    public void Close()
    {

    }

}
