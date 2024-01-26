using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

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

    void DealDamge()
    {
        monster?.TakeDamage(damage);
    }
    public void SetTarget(Monster target)
    {
        monster = target;
    }
    private void Awake()
    {
        keyToPushText.text = damageKey.ToString();
    }
    void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Death();
    }
    void Death()
    {
        OnKilledByPlayer.Invoke();
        Instantiate(OnKilledEffect,transform.position,Quaternion.identity);

        if(comboButton)
        {
           GameObject newClicky =  Instantiate(comboClickies[0].gameObject,transform.position + Vector3.right,Quaternion.identity);
            comboClickies.RemoveAt(0);
            if(comboClickies.Count > 0)
            {
                Clicky comboClicky = newClicky.GetComponent<Clicky>();
                comboClicky.comboClickies = new List<Clicky>(comboClickies);
                comboClicky.comboButton = true;
                comboClicky.SetTarget(monster);

            }
           
        }

        Destroy(this.gameObject);
    }
    void OnLifetimeRunOut()
    {
        Destroy(this.gameObject);
    }
    private void Update()
    {
        lifetime -= 1 * Time.deltaTime;
        if(lifetimeText != null)
        {
            lifetimeText.text = lifetime.ToString("F2");
        }

        if (lifetime < 0)
            OnLifetimeRunOut();

        if (Input.GetKeyDown(damageKey))
        {
            TakeDamage(1);
            DealDamge();
        }
    }


}
