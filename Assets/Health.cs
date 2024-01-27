
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health =5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {

            if(i<health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

}
