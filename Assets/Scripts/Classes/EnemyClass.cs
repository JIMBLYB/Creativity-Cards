﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass
{
    // Basic information
    public string enemyName;
    public Mesh model;

    // Basic Stats
    public int health;
    public int damage;
    public float heavyModifier;
    public int movementSpeed;

    // What happens when this enemy dies
    public int moneyEarned;
    // Add particle effect if needed

    // References to other object/scripts
    public GameController gameController;
    // Bool to show whether the enemy has finished their attack
    public bool finishedAttack = false;

    // Constructors for varying amounts of inputs
    public EnemyClass()
    {
       health = 1;
       damage = 1;
       heavyModifier = 1.5f;
       movementSpeed = 5;
    }
    public EnemyClass(int hp, int dmg)
    {
        health = hp;
        damage = dmg;
    }

    public EnemyClass(string name, int hp, int dmg)
    {
        enemyName = name;
        health = hp;
        damage = dmg;
    }

    public EnemyClass(int hp, int dmg, float hevMod)
    {
        health = hp;
        damage = dmg;
        heavyModifier = hevMod;
    }

    public EnemyClass(string name, int hp, int dmg, float hevMod)
    {
        enemyName = name;
        health = hp;
        damage = dmg;
        heavyModifier = hevMod;
    }

    // "Intelligently" chooses which type of attack to perform
    public void DecideAttack()
    {
        // Randomly chooses based on bool value
        switch (Random.value > 0.5f)
        {
            case false:
                LightAttack();
                break;

            case true:
                HeavyAttack();
                break;
        }

        finishedAttack = true;
    }

    // Light attack dealing base damage
    public void LightAttack()
    {
        gameController.health -= damage;
        Debug.Log("Light");
    }

    // Heavy attack dealing a damage multiplicative of the heavy modifier
    // (Default modifier = 1.5)
    public void HeavyAttack()
    {
        gameController.health -= Mathf.FloorToInt(damage * heavyModifier);
        Debug.Log("Heavy");
    }

    // Removes health based on damage
    public void TakeDamage(int hitDamage)
    {
        health -= hitDamage;
    }

    // All procudures following death
    private void Die(GameObject enemy)
    {
        // Gives moneyEarned value to player
        gameController.money += moneyEarned;
        Debug.Log(enemyName + " has died");
        Object.Destroy(enemy);
    }
}
