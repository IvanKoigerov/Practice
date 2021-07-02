using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool active;
    public BoolValue activeValue;
    public Sprite ActiveSprite;
    private SpriteRenderer mySprite;
    public Door thisDoor;
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = activeValue.RunTimeValue;
        if (active)
        {
            Activate();
        }
    }

    public void Activate()
    {
        active = true;
        activeValue.RunTimeValue = active;
        thisDoor.Open();
        mySprite.sprite = ActiveSprite;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Activate();
        }
    }
}
