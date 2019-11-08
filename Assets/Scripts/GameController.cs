using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int money;

    [SerializeField]
    public int maxHealth;
    public int health;

    // Initialisation of variables
    public void Awake()
    {
        // Keeps object persistant across scenes
        DontDestroyOnLoad(this);

        // Sets health to the max
        health = maxHealth;

        //Resets money
        money = 0;
    }
}
