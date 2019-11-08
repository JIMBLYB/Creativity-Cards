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
    public float heavyModifier;

    // What happens when this enemy dies
    public int moneyEarned;
    // Add particle effect if needed

    // References to other object/scripts
    private GameController gameController;

    // Any initialization
    public void Awake()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Light attack dealing base damage
    public void LightAttack()
    {
        gameController.health -= damage;
    }

    // Heavy attack dealing a damage multiplicative of the heavy modifier
    // (Default modifier = 1.5)
    public void HeavyAttack()
    {
        gameController.health -= Mathf.FloorToInt(damage * heavyModifier);
    }

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

    // All procudures following death
    public void Die()
    {
        // Gives moneyEarned value to player
        gameController.money += moneyEarned;
        Debug.Log(enemyName + " has died");
        Object.Destroy(this);
    }
}
