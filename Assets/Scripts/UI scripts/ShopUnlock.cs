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
    public GameObject moneyAmount;
    public GameObject NEGText;
    public GameController moneyStorage;

    void Start()
    {
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

        Button unbtn1 = unlockButton1.GetComponent<Button>();
        Button unbtn2 = unlockButton2.GetComponent<Button>();
        Button unbtn3 = unlockButton3.GetComponent<Button>();
        Button unbtn4 = unlockButton4.GetComponent<Button>();
        Button unbtn5 = unlockButton5.GetComponent<Button>();
        Button unbtn6 = unlockButton6.GetComponent<Button>();
        //listening for click
        unbtn1.onClick.AddListener(unlockButton1Clicked);
        unbtn2.onClick.AddListener(unlockButton2Clicked);
        unbtn3.onClick.AddListener(unlockButton3Clicked);
        unbtn4.onClick.AddListener(unlockButton4Clicked);
        unbtn5.onClick.AddListener(unlockButton5Clicked);
        unbtn6.onClick.AddListener(unlockButton6Clicked);
    }
    private void Update()
    {
        //calls void which displays money
        showMoney();
    }

    //Tests to see if player has enough money: If they do the locking overlay is displayed for that animal.
    void unlockButton1Clicked()
    {
        if (moneyStorage.money >= 150)
        {
            unlockScreen1.SetActive(false);
            unlockScreenButton1.SetActive(false);
            moneyStorage.money = moneyStorage.money - 150;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton2Clicked()
    {
        if (moneyStorage.money >= 250)
        {
            unlockScreen2.SetActive(false);
            unlockScreenButton2.SetActive(false);
            moneyStorage.money = moneyStorage.money - 250;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton3Clicked()
    {
        if (moneyStorage.money >= 400)
        {
            unlockScreen3.SetActive(false);
            unlockScreenButton3.SetActive(false);
            moneyStorage.money = moneyStorage.money - 400;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton4Clicked()
    {
        if (moneyStorage.money >= 600)
        {
            unlockScreen4.SetActive(false);
            unlockScreenButton4.SetActive(false);
            moneyStorage.money = moneyStorage.money - 600;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton5Clicked()
    {
        if (moneyStorage.money >= 800)
        {
            unlockScreen5.SetActive(false);
            unlockScreenButton5.SetActive(false);
            moneyStorage.money = moneyStorage.money - 800;
        }
        else
        {
            notEnoughGold();
        }
    }
    void unlockButton6Clicked()
    {
        if (moneyStorage.money >= 950)
        {
            unlockScreen6.SetActive(false);
            unlockScreenButton6.SetActive(false);
            moneyStorage.money = moneyStorage.money - 950;
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

    IEnumerator timerNEGText()
    {
        yield return new WaitForSeconds(0.5f);
        //when timer finishes disables text
        NEGText.SetActive(false);
    }
}
