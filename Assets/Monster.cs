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
        lifeText.text = health.ToString();
        if (health <= 0) Death();
    }
    void Death()
    {
        OnKilledByPlayer.Invoke();
        Instantiate(OnKilledEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void Update()
    {
       
    }
}
