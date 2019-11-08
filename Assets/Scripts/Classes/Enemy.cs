using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Basic information
    public string enemyName;
    public Mesh model;

    // Basic Stats
    public int health;
    public int damage;

    // Removes health based on damage
    public void TakeDamage(int hitDamage)
    {
        health -= hitDamage;
        // 'Kills' enemy when health reaches 0
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log(enemyName + " has died");
        Object.Destroy(this);
    }

    public void LightAttack()
    {
        // Deal 1.0x damage
    }

    public void HeavyAttack()
    {
        // Deal 1.5x damage
    }
}
