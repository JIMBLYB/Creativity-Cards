using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int money;

    [SerializeField]
    public int maxHealth;
    public int health;
    public int sheepLvl, cowLvl, chickenLvl, chickLvl, sample1Lvl, sample2Lvl;
    public bool sheepLock, cowLock, chickenLock, chickLock, sample1Lock, sample2Lock;

    // Initialisation of variables
    public void Awake()
    {
        // Keeps object persistant across scenes
        DontDestroyOnLoad(this);

        // Sets health to the max
        health = maxHealth;

        //Resets money
        money = 500;

        //Sets animal starting level
        sheepLvl = 1;
        cowLvl = 1;
        chickenLvl = 1;
        chickLvl = 1;
        sample1Lvl = 1;
        sample2Lvl = 1;

        //set animal locked status;
        sheepLock = true;
        cowLock = true;
        chickenLock = true;
        chickLock = true;
        sample1Lock = true;
        sample2Lock = true;

    }
}
