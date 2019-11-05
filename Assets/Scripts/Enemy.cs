using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public Mesh model;

    public int health;

    public int damage;

    public void TakeDamage(int hitDamage)
    {
        health -= hitDamage;
    }

    public void Die()
    {
        Debug.Log(enemyName + " has died");
        Object.Destroy(this);
    }
}
