using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public int money;

    [SerializeField]
    public int maxHealth;
    public int health;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        health = maxHealth;
        money = 0;
    }
}
