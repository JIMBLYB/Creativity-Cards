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
    public GameObject sheepLevel, cowLevel, chickenLevel, chickLevel, pigLevel, gooseLevel;
    public GameObject sheepUnlock, cowUnlock, chickenUnlock, chickUnlock, pigUnlock, gooseUnlock;
    public GameObject sheepUpgrade, cowUpgrade, chickenUpgrade, chickUpgrade, pigUpgrade, gooseUpgrade;
    public GameObject NEGText;
    public GameController moneyStorage;
    public GameController LvlStorage;
    public GameController lockedStatus;
    float updatePriceSheep1, updatePriceSheep2, updatePriceCow1, updatePriceCow2, updatePriceChicken1, updatePriceChicken2, updatePriceChick1, updatePriceChick2, updatePricePig1, updatePricePig2, updatePriceGoose1, updatePriceGoose2;
    float sheepUpgradeCost, cowUpgradeCost, chickenUpgradeCost, chickUpgradeCost, pigUpgradeCost, gooseUpgradeCost;
    public int sheepUnlockCost, cowUnlockCost, chickenUnlockCost, chickUnlockCost, pigUnlockCost, gooseUnlockCost;

    void Start()
    {
        moneyStorage = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        LvlStorage = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        lockedStatus = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        //sets the animal unlock cost;
        sheepUnlockCost = 150;
        cowUnlockCost = 300;
        chickenUnlockCost = 400;
        chickUnlockCost = 600;
        pigUnlockCost = 800;
        gooseUnlockCost = 950;

        //Sets the Not Enough Gold text to false;
        NEGText.SetActive(false);

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
        //calls void which displays money, level of animals, price of unlock, price of upgrades
        showMoney();
        displayLevel();
        displayUnlockPrice();
        displayUpgradePrice();

        //Calculating the cost of base upgrades

        updatePriceSheep1 = 6 * LvlStorage.sheepLvl;
        updatePriceSheep2 = Mathf.Pow(updatePriceSheep1, 1.5f);
        updatePriceCow1 = 6 * LvlStorage.cowLvl;
        updatePriceCow2 = Mathf.Pow(updatePriceCow1, 1.5f);
        updatePriceChicken1 = 6 * LvlStorage.chickenLvl;
        updatePriceChicken2 = Mathf.Pow(updatePriceChicken1, 1.5f);
        updatePriceChick1 = 6 * LvlStorage.chickLvl;
        updatePriceChick2 = Mathf.Pow(updatePriceChick1, 1.5f);
        updatePricePig1 = 6 * LvlStorage.pigLvl;
        updatePricePig2 = Mathf.Pow(updatePricePig1, 1.5f);
        updatePriceGoose1 = 6 * LvlStorage.gooseLvl;
        updatePriceGoose2 = Mathf.Pow(updatePriceGoose1, 1.5f);

        sheepUpgradeCost = Mathf.Round(updatePriceSheep2);
        cowUpgradeCost = Mathf.Round(updatePriceCow2);
        chickenUpgradeCost = Mathf.Round(updatePriceChicken2);
        chickUpgradeCost = Mathf.Round(updatePriceChick2);
        pigUpgradeCost = Mathf.Round(updatePricePig2);
        gooseUpgradeCost = Mathf.Round(updatePriceGoose2);

        if (lockedStatus.sheepLock == false)
        {
            unlockScreen1.SetActive(false);
            unlockScreenButton1.SetActive(false);
        }
        if(lockedStatus.cowLock == false)
        {
            unlockScreen2.SetActive(false);
            unlockScreenButton2.SetActive(false);
        }
        if (lockedStatus.chickenLock == false)
        {
            unlockScreen3.SetActive(false);
            unlockScreenButton3.SetActive(false);
        }
        if (lockedStatus.chickLock == false)
        {
            unlockScreen4.SetActive(false);
            unlockScreenButton4.SetActive(false);
        }
        if (lockedStatus.pigLock == false)
        {
            unlockScreen5.SetActive(false);
            unlockScreenButton5.SetActive(false);
        }
        if (lockedStatus.gooseLock == false)
        {
            unlockScreen6.SetActive(false);
            unlockScreenButton6.SetActive(false);
        }
    }

    //Tests to see if player has enough money: If they do the locking overlay is displayed for that animal.
    void unlockButton1Clicked()
    {
        if (moneyStorage.money >= sheepUnlockCost)
        {
            lockedStatus.sheepLock = false;
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
            lockedStatus.cowLock = false;
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
            lockedStatus.chickenLock = false;
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
            lockedStatus.chickLock = false;
            moneyStorage.money = moneyStorage.money - chickUnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton5Clicked()
    {
        if (moneyStorage.money >= pigUnlockCost)
        {
            lockedStatus.pigLock = false;
            moneyStorage.money = moneyStorage.money - pigUnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton6Clicked()
    {
        if (moneyStorage.money >= gooseUnlockCost)
        {
            lockedStatus.gooseLock = false;
            moneyStorage.money = moneyStorage.money - gooseUnlockCost;
        }
        else
        {
            notEnoughGold();
        }
    }

    //Upgrade buttons
    void upgradebutton1Clicked()
    {
        if (moneyStorage.money >= sheepUpgradeCost)
        {
            LvlStorage.sheepLvl = LvlStorage.sheepLvl + 1;
            moneyStorage.money = moneyStorage.money - sheepUpgradeCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void upgradebutton2Clicked()
    {
        if (moneyStorage.money >= cowUpgradeCost)
        {
            LvlStorage.cowLvl = LvlStorage.cowLvl + 1;
            moneyStorage.money = moneyStorage.money - cowUpgradeCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void upgradebutton3Clicked()
    {
        if (moneyStorage.money >= chickenUpgradeCost)
        {
            LvlStorage.chickenLvl = LvlStorage.chickenLvl + 1;
            moneyStorage.money = moneyStorage.money - chickenUpgradeCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void upgradebutton4Clicked()
    {
        if (moneyStorage.money >= chickUpgradeCost)
        {
            LvlStorage.chickLvl = LvlStorage.chickLvl + 1;
            moneyStorage.money = moneyStorage.money - chickUpgradeCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void upgradebutton5Clicked()
    {
        if (moneyStorage.money >= pigUpgradeCost)
        {
            LvlStorage.pigLvl = LvlStorage.pigLvl + 1;
            moneyStorage.money = moneyStorage.money - pigUpgradeCost;
        }
        else
        {
            notEnoughGold();
        }
    }
    void upgradebutton6Clicked()
    {
        if (moneyStorage.money >= gooseUpgradeCost)
        {
            LvlStorage.gooseLvl = LvlStorage.gooseLvl + 1;
            moneyStorage.money = moneyStorage.money - gooseUpgradeCost;
        }
        else
        {
            notEnoughGold();
        }
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
        pigLevel.GetComponent<Text>().text = "lvl - " + LvlStorage.pigLvl.ToString();
        gooseLevel.GetComponent<Text>().text = "lvl - " + LvlStorage.gooseLvl.ToString();
    }
    public void displayUnlockPrice()
    {
        sheepUnlock.GetComponent<Text>().text = "Unlock - " + sheepUnlockCost.ToString();
        cowUnlock.GetComponent<Text>().text = "Unlock - " + cowUnlockCost.ToString();
        chickenUnlock.GetComponent<Text>().text = "Unlock - " + chickenUnlockCost.ToString();
        chickUnlock.GetComponent<Text>().text = "Unlock - " + chickUnlockCost.ToString();
        pigUnlock.GetComponent<Text>().text = "Unlock - " + pigUnlockCost.ToString();
        gooseUnlock.GetComponent<Text>().text = "Unlock - " + gooseUnlockCost.ToString();
    }
    public void displayUpgradePrice()
    {
        sheepUpgrade.GetComponent<Text>().text = "Upgrade - " + sheepUpgradeCost.ToString();
        cowUpgrade.GetComponent<Text>().text = "Upgrade - " + cowUpgradeCost.ToString();
        chickenUpgrade.GetComponent<Text>().text = "Upgrade - " + chickenUpgradeCost.ToString();
        chickUpgrade.GetComponent<Text>().text = "Upgrade - " + chickUpgradeCost.ToString();
        pigUpgrade.GetComponent<Text>().text = "Upgrade - " + pigUpgradeCost.ToString();
        gooseUpgrade.GetComponent<Text>().text = "Upgrade - " + gooseUpgradeCost.ToString();
    }

    //NEG timer
    IEnumerator timerNEGText()
    {
        yield return new WaitForSeconds(0.5f);
        //when timer finishes disables text
        NEGText.SetActive(false);
    }
}
