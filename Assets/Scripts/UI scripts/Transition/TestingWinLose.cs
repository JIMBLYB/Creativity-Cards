using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestingWinLose : MonoBehaviour
{
    public GameController GCInfo;

    void Start()
    {
        GCInfo = GameObject.FindWithTag("GameController").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        //testing conditions
        if (Input.GetKeyDown("space"))
        {
            GCInfo.marrowHealth = 0;
        }
        if (Input.GetKeyDown("return"))
        {
            GCInfo.dayNum = 5;
        }
        if (Input.GetKeyDown("backspace"))
        {
            GCInfo.marrowHealth = GCInfo.marrowHealth - 17;
        }
        if (Input.GetKeyDown("tab"))
        {
            GCInfo.dayNum = GCInfo.dayNum + 1;
        }
    }
}
