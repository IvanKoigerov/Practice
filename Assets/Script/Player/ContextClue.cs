using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject context;
    public bool contaxtActive = false;
    public void Enable()
    {
        context.SetActive(true);
    }

    public void Disable()
    {
        context.SetActive(false);
    }

    public void ChangeContext()
    {
        contaxtActive = !contaxtActive;
        if (contaxtActive)
        {
            context.SetActive(true);
        }
        else
        {
            context.SetActive(false);
        }
    }

}
