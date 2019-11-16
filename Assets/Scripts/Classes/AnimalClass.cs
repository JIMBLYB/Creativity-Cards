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
    private int levelUpIncrease;
    public float hitChance;
    public float cooldownDuration;

    // Variables for shop
    public bool unlocked;
    public int buyPrice;
    public int currentPrice;
    private float priceMultiplier;

    public void Pricing()
    {
        if (!unlocked)
        {
            currentPrice = buyPrice;
        }
        else
        {
            currentPrice = Mathf.FloorToInt(currentPrice * priceMultiplier);
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

    public void Upgrade()
    {
        level++;
        Pricing();
        damage += levelUpIncrease;
    }
}
