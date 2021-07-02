using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaSign : Interectable
{



    public GameObject DiaBox;
    public Text diaText;
    public string dia;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& InRange)
        {
            if (DiaBox.activeInHierarchy)
            {
                DiaBox.SetActive(false);

            }
            else
            {
                DiaBox.SetActive(true);
                diaText.text = dia;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            InRange = true;
            contextOn.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            InRange = false;
            DiaBox.SetActive(false);
            contextOff.Raise();
        }
    }


}
