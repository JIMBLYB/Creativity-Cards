using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalClass : MonoBehaviour
{
    // GameObject references
    public GameController gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

    // Variables for use during battle
    public int level;
    public int damage;
    public float levelUpIncrease;
    public float hitChance;
    public float cooldownDuration;

    // Variables for shop
    public bool unlocked;
    public int buyPrice;
    public int currentPrice;
    public float increaseMult;

    public void Pricing()
    {
        if (!unlocked)
        {
            currentPrice = buyPrice;
        }
        else
        {
            currentPrice = Mathf.CeilToInt(currentPrice * increaseMult);
        }
    }

    public void Purchasing()
    {
        if (gameController.money >= currentPrice)
        {
            if (!unlocked)
            {
                unlocked = true;
                level = 1;
                Pricing();
            }
            else
            {
                level++;
                Pricing();
                damage = Mathf.FloorToInt(damage * levelUpIncrease);
            }
        }
    }
}
