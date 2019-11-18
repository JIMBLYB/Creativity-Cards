using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManagerTeamScene : MonoBehaviour
{
    public GameController unlockedAnimals;
    public GameObject sheepLockOverlay;

    void Update()
    {
        if(unlockedAnimals.sheepLock == false)
        {
            sheepLockOverlay.SetActive(false);
            Debug.Log("cheesus");
        }
        else
        {
            sheepLockOverlay.SetActive(true);
        }
    }

}
