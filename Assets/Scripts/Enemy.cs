using System;
using Damagable;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]private int maxhealth = 100;
    
    private int currentHealth;

    private void Start() => currentHealth = maxhealth;

    public void Damage(int damageAmount)
    {
        currentHealth-=damageAmount;
        Debug.Log(currentHealth);
    }
}
