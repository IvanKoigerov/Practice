using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [Header("")]
    public Image[] hearts;
    [Header("")]
    public Sprite FullHeart;
    public Sprite HalfFulHeart;
    public Sprite emptyHealth;
    [Header("")]
    public FloatValue someHearts;
    public FloatValue PlayerHP;
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0;  i < someHearts.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = FullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHeath = PlayerHP.RunTimeValue / 2;
        for (int i = 0; i < someHearts.RunTimeValue; i++)
        {
            if (i <= tempHeath-1)
            {
                hearts[i].sprite = FullHeart;
                
            }
            else if (i >= tempHeath)
            {
                hearts[i].sprite = emptyHealth;
            }
            else
            {
                hearts[i].sprite = HalfFulHeart;
            }
        }

    }
}
