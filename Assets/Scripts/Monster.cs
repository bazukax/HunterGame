using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Monster : MonoBehaviour
{
    public int health = 100;
  
    public int damage = 3;


    [SerializeField] private UnityEvent OnKilledByPlayer;
    [SerializeField] GameObject OnKilledEffect;
    [SerializeField] TMP_Text lifeText;

    public Health hpUI;
    void DealDamge()
    {

    }
    private void Awake()
    {
        lifeText.text = health.ToString();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        hpUI.health = health;
        lifeText.text = health.ToString();
        if (health <= 0) Death();
    }
    void Death()
    {
        hpUI.health = 0;
        OnKilledByPlayer.Invoke();
        Instantiate(OnKilledEffect, transform.position, Quaternion.identity);
        enabled = false;
    }

    private void Update()
    {
       
    }
}
