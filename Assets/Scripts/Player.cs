using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;
    public Health hpUI;
    public SpriteRenderer spriteRenderer;
    public void TakeDamage(int amount)
    {
        health -= amount;
        hpUI.health = health;
        Invoke("ChangeColor", 4f);
       

    }
    public void ChangeColor()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1 - (health * 0.2f));
    }

}
