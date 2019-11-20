using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManagerTeamScene : MonoBehaviour
{
    public GameController unlockedAnimals;
    public GameObject sheepLockOverlay, cowLockOverlay, chickenLockOverlay, chickLockOverlay, pigLockOverlay, gooseLockOverlay;
    public GameObject sheepLevel, cowLevel, chickenLevel, chickLevel, pigLevel, gooseLevel;
    private bool firstRun;

    private void Start()
    {
        unlockedAnimals = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        firstRun = true;

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

    private void Update()
    { //testing for first run, prevents display level from repeating
        if (firstRun == true)
        {
            displayLevel();
            firstRun = false;
        }
    }

    public void displayLevel()
    {
        //gets existing text and adds lvl of animal
        sheepLevel.GetComponent<Text>().text = sheepLevel.GetComponent<Text>().text + " lvl - " + unlockedAnimals.sheepLvl.ToString();
        cowLevel.GetComponent<Text>().text = cowLevel.GetComponent<Text>().text + " lvl - " + unlockedAnimals.cowLvl.ToString();
        chickenLevel.GetComponent<Text>().text = chickenLevel.GetComponent<Text>().text + " lvl - " + unlockedAnimals.chickenLvl.ToString();
        chickLevel.GetComponent<Text>().text = chickLevel.GetComponent<Text>().text + " lvl - " + unlockedAnimals.chickLvl.ToString();
        pigLevel.GetComponent<Text>().text = pigLevel.GetComponent<Text>().text + " lvl - " + unlockedAnimals.pigLvl.ToString();
        gooseLevel.GetComponent<Text>().text = gooseLevel.GetComponent<Text>().text + " lvl - " + unlockedAnimals.gooseLvl.ToString();
    }
}
