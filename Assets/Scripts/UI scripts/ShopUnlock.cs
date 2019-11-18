using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUnlock : MonoBehaviour
{
    //This script unlocks the animals + upgrades

    public Button unlockButton1, unlockButton2, unlockButton3, unlockButton4, unlockButton5, unlockButton6;
    public GameObject unlockScreen1, unlockScreen2, unlockScreen3, unlockScreen4, unlockScreen5, unlockScreen6;
    public GameObject unlockScreenButton1, unlockScreenButton2, unlockScreenButton3, unlockScreenButton4, unlockScreenButton5, unlockScreenButton6;
    public GameObject upgradeButton1, upgradeButton2, upgradeButton3, upgradeButton4, upgradeButton5, upgradeButton6;
    public GameObject moneyAmount;
    public GameObject sheepLevel, cowLevel, chickenLevel, chickLevel, sample1Level, sample2Level;
    public GameObject sheepUnlock, cowUnlock, chickenUnlock, chickUnlock, sample1Unlock, sample2Unlock;
    public GameObject NEGText;
    public GameController moneyStorage;
    public GameController LvlStorage;
    public int sheepUnlockCost, cowUnlockCost, chickenUnlockCost, chickUnlockCost, sample1UnlockCost, sample2UnlockCost;

    void Start()
    {
        //sets the animal unlock cost;
        sheepUnlockCost = 150;
        cowUnlockCost = 300;
        chickenUnlockCost = 400;
        chickUnlockCost = 600;
        sample1UnlockCost = 800;
        sample2UnlockCost = 950;

        //Sets the Not Enough Gold text to false;
        NEGText.SetActive(false);

        //ensures unlock UI is active
        unlockScreen1.SetActive(true);
        unlockScreen2.SetActive(true);
        unlockScreen3.SetActive(true);
        unlockScreen4.SetActive(true);
        unlockScreen5.SetActive(true);
        unlockScreen6.SetActive(true);
        unlockScreenButton1.SetActive(true);
        unlockScreenButton2.SetActive(true);
        unlockScreenButton3.SetActive(true);
        unlockScreenButton4.SetActive(true);
        unlockScreenButton5.SetActive(true);
        unlockScreenButton6.SetActive(true);

        //setting up the unlock and upgrade buttons
        Button unbtn1 = unlockButton1.GetComponent<Button>();
        Button unbtn2 = unlockButton2.GetComponent<Button>();
        Button unbtn3 = unlockButton3.GetComponent<Button>();
        Button unbtn4 = unlockButton4.GetComponent<Button>();
        Button unbtn5 = unlockButton5.GetComponent<Button>();
        Button unbtn6 = unlockButton6.GetComponent<Button>();

        Button upgbtn1 = upgradeButton1.GetComponent<Button>();
        Button upgbtn2 = upgradeButton2.GetComponent<Button>();
        Button upgbtn3 = upgradeButton3.GetComponent<Button>();
        Button upgbtn4 = upgradeButton4.GetComponent<Button>();
        Button upgbtn5 = upgradeButton5.GetComponent<Button>();
        Button upgbtn6 = upgradeButton6.GetComponent<Button>();

        //listening for upgrading and unlocking clicks
        unbtn1.onClick.AddListener(unlockButton1Clicked);
        unbtn2.onClick.AddListener(unlockButton2Clicked);
        unbtn3.onClick.AddListener(unlockButton3Clicked);
        unbtn4.onClick.AddListener(unlockButton4Clicked);
        unbtn5.onClick.AddListener(unlockButton5Clicked);
        unbtn6.onClick.AddListener(unlockButton6Clicked);

        upgbtn1.onClick.AddListener(upgradebutton1Clicked);
        upgbtn2.onClick.AddListener(upgradebutton2Clicked);
        upgbtn3.onClick.AddListener(upgradebutton3Clicked);
        upgbtn4.onClick.AddListener(upgradebutton4Clicked);
        upgbtn5.onClick.AddListener(upgradebutton5Clicked);
        upgbtn6.onClick.AddListener(upgradebutton6Clicked);
    }
    private void Update()
    {
        //calls void which displays money
        showMoney();
        displayLevel();
        displayUnlockPrice();
    }

    //Tests to see if player has enough money: If they do the locking overlay is displayed for that animal.
    void unlockButton1Clicked()
    {
        if (moneyStorage.money >= sheepUnlockCost)
        {
            unlockScreen1.SetActive(false);
            unlockScreenButton1.SetActive(false);
            moneyStorage.money = moneyStorage.money - sheepUnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton2Clicked()
    {
        if (moneyStorage.money >= cowUnlockCost)
        {
            unlockScreen2.SetActive(false);
            unlockScreenButton2.SetActive(false);
            moneyStorage.money = moneyStorage.money - cowUnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton3Clicked()
    {
        if (moneyStorage.money >= chickenUnlockCost)
        {
            unlockScreen3.SetActive(false);
            unlockScreenButton3.SetActive(false);
            moneyStorage.money = moneyStorage.money - chickenUnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton4Clicked()
    {
        if (moneyStorage.money >= chickUnlockCost)
        {
            unlockScreen4.SetActive(false);
            unlockScreenButton4.SetActive(false);
            moneyStorage.money = moneyStorage.money - chickUnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton5Clicked()
    {
        if (moneyStorage.money >= sample1UnlockCost)
        {
            unlockScreen5.SetActive(false);
            unlockScreenButton5.SetActive(false);
            moneyStorage.money = moneyStorage.money - sample1UnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton6Clicked()
    {
        if (moneyStorage.money >= sample2UnlockCost)
        {
            unlockScreen6.SetActive(false);
            unlockScreenButton6.SetActive(false);
            moneyStorage.money = moneyStorage.money - sample2UnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }

    //Upgrade buttons
    void upgradebutton1Clicked()
    {
        LvlStorage.sheepLvl = LvlStorage.sheepLvl + 1;
    }
    void upgradebutton2Clicked()
    {
        LvlStorage.cowLvl = LvlStorage.cowLvl + 1;
    }
    void upgradebutton3Clicked()
    {
        LvlStorage.chickenLvl = LvlStorage.chickenLvl + 1;
    }
    void upgradebutton4Clicked()
    {
        LvlStorage.chickLvl = LvlStorage.chickLvl + 1;
    }
    void upgradebutton5Clicked()
    {
        LvlStorage.sample1Lvl = LvlStorage.sample1Lvl + 1;
    }
    void upgradebutton6Clicked()
    {
        LvlStorage.sample2Lvl = LvlStorage.sample2Lvl + 1;
    }

    //not enough gold, for when player doesnt have enough gold
    public void notEnoughGold()
    {
        NEGText.SetActive(true);
        //activates timer
        StartCoroutine(timerNEGText());
    }

    //displays money int from the GameController script
    public void showMoney()
    {
        moneyAmount.GetComponent<Text>().text = moneyStorage.money.ToString();
    }

    //displays the level of the animals
    public void displayLevel()
    {
        sheepLevel.GetComponent<Text>().text = "lvl - " + LvlStorage.sheepLvl.ToString();
        cowLevel.GetComponent<Text>().text = "lvl - " + LvlStorage.cowLvl.ToString();
        chickenLevel.GetComponent<Text>().text = "lvl - " + LvlStorage.chickenLvl.ToString();
        chickLevel.GetComponent<Text>().text = "lvl - " + LvlStorage.chickLvl.ToString();
        sample1Level.GetComponent<Text>().text = "lvl - " + LvlStorage.sample1Lvl.ToString();
        sample2Level.GetComponent<Text>().text = "lvl - " + LvlStorage.sample2Lvl.ToString();
    }

    public void displayUnlockPrice()
    {
        sheepUnlock.GetComponent<Text>().text = "Unlock - " + sheepUnlockCost.ToString();
        cowUnlock.GetComponent<Text>().text = "Unlock - " + cowUnlockCost.ToString();
        chickenUnlock.GetComponent<Text>().text = "Unlock - " + chickenUnlockCost.ToString();
        chickUnlock.GetComponent<Text>().text = "Unlock - " + chickUnlockCost.ToString();
        sample1Unlock.GetComponent<Text>().text = "Unlock - " + sample1UnlockCost.ToString();
        sample2Unlock.GetComponent<Text>().text = "Unlock - " + sample2UnlockCost.ToString();
    }

    //NEG timer
    IEnumerator timerNEGText()
    {
        yield return new WaitForSeconds(0.5f);
        //when timer finishes disables text
        NEGText.SetActive(false);
    }
}
