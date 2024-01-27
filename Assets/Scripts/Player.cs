using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;
    public Health hpUI;
    public void TakeDamage(int amount)
    {
        health -= amount;
        hpUI.health = health;
        if (health <= 0) Death();
    }
    public void Death()
    {

    }

}
