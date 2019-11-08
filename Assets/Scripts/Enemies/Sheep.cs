using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Enemy
{
    public int hp;
    public int dmg;
    public float hevMod;

    public override void Awake()
    {
        base.Awake();
        Enemy Sheep = new Enemy("Sheep", hp, dmg, hevMod);
    }
}
