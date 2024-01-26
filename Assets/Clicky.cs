using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Clicky : MonoBehaviour
{
    public int health = 1;
    public float lifetime = 2;
    public int damage = 3;

    public KeyCode damageKey = KeyCode.Q;

    [SerializeField] private UnityEvent OnKilledByPlayer;
    [SerializeField] GameObject OnKilledEffect;

    [SerializeField] TMP_Text lifetimeText;
    [SerializeField] TMP_Text keyToPushText;

    public bool comboButton = false;
    public List<Clicky> comboClickies = new List<Clicky>();

    Monster monster;
   [SerializeField] SimpleClickHandler clickHandler;
    void DealDamge()
    {
        monster?.TakeDamage(damage);
    }
    public void SetTarget(Monster target)
    {
        monster = target;
    }
    public void SetClickHandler(SimpleClickHandler clickHandler)
    {
        this.clickHandler = clickHandler;
    }
    private void Awake()
    {
        keyToPushText.text = damageKey.ToString();

    }
    private void Start()
    {
        if (clickHandler != null)
            clickHandler.OnKeyboardClick += HandleKeyClick;
    }
    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Death();
    }
    void Death()
    {
        OnKilledByPlayer.Invoke();
        Instantiate(OnKilledEffect, transform.position, Quaternion.identity);

        if (comboButton)
        {
            GameObject newClicky = Instantiate(comboClickies[0].gameObject, transform.position + Vector3.right, Quaternion.identity);
            Clicky comboClicky = newClicky.GetComponent<Clicky>();
            comboClicky.SetClickHandler(clickHandler);
            comboClickies.RemoveAt(0);
            if (comboClickies.Count > 0)
            {
       
              
                comboClicky.comboClickies = new List<Clicky>(comboClickies);
                comboClicky.comboButton = true;
                comboClicky.SetTarget(monster);
               
            }

        }
        if (clickHandler != null)
            clickHandler.OnKeyboardClick -= HandleKeyClick;
        Destroy(this.gameObject);
    }
    void OnLifetimeRunOut()
    {
        if (clickHandler != null)
            clickHandler.OnKeyboardClick -= HandleKeyClick;
        Destroy(this.gameObject);
    }
    private void Update()
    {
        lifetime -= 1 * Time.deltaTime;
        if (lifetimeText != null)
        {
            lifetimeText.text = lifetime.ToString("F2");
        }

        if (lifetime < 0)
            OnLifetimeRunOut();

    }


    private void HandleKeyClick(KeyCode code)
    {
        if (code == damageKey)
        {
            TakeDamage(1);
            DealDamge();
        }
        else
        {
            OnLifetimeRunOut();
        }
    }



}
