using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManagerTeamScene : MonoBehaviour
{
    public GameController unlockedAnimals;
    public GameObject sheepLockOverlay, cowLockOverlay, chickenLockOverlay, chickLockOverlay, pigLockOverlay, gooseLockOverlay;

    private void Start()
    {
        unlockedAnimals = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        if(unlockedAnimals.sheepLock == false)
        {
            sheepLockOverlay.SetActive(false);
        }
        else
        {
            sheepLockOverlay.SetActive(true);
        }

        if (unlockedAnimals.cowLock == false)
        {
            cowLockOverlay.SetActive(false);
        }
        else
        {
            cowLockOverlay.SetActive(true);
        }

        if (unlockedAnimals.chickenLock == false)
        {
            chickenLockOverlay.SetActive(false);
        }
        else
        {
            chickenLockOverlay.SetActive(true);
        }

        if (unlockedAnimals.chickLock == false)
        {
            chickLockOverlay.SetActive(false);
        }
        else
        {
            chickLockOverlay.SetActive(true);
        }

        if (unlockedAnimals.pigLock == false)
        {
            pigLockOverlay.SetActive(false);
        }
        else
        {
            pigLockOverlay.SetActive(true);
        }

        if (unlockedAnimals.gooseLock == false)
        {
            gooseLockOverlay.SetActive(false);
        }
        else
        {
            gooseLockOverlay.SetActive(true);
        }
    }
}
