using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public int money;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        money = 0;
    }
}
