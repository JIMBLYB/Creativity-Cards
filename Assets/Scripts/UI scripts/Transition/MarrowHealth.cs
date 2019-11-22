using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarrowHealth : MonoBehaviour
{
    public GameObject loseMarrow;
    public GameObject winMarrow;
    public GameObject regMarrow;
    public GameObject moneyText;
    public GameObject menuButton, quitButton, nextButton;
    public GameObject dayTitle, marrowHealth, marrowTitle;
    private bool dayCycle, healthPerCycle;
    public GameController GCInfo;
    private bool lastRoundLose;
    // Start is called before the first frame update
    void Start()
    {
        GCInfo = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        dayCycle = true;
        healthPerCycle = true;
        lastRoundLose = false;
    }

    void Update()
    {
        showMoney();

        //tests to see if player's health has hit 0
        if (GCInfo.marrowHealth <= 0)
        {
            dayCycle = false;
            healthPerCycle = false;
            loseMarrow.SetActive(true);
            regMarrow.SetActive(false);
            dayTitle.GetComponent<Text>().text = "You Lost!".ToString();
            marrowTitle.GetComponent<Text>().text = "Your marrow was destroyed! Better luck next year.".ToString();
            nextButton.SetActive(false);
            menuButton.SetActive(true);
            quitButton.SetActive(true);
            lastRoundLose = true;
        }

        //tests to see if the game has reached max rounds
        if (GCInfo.dayNum >= GCInfo.maxRounds && lastRoundLose == false)
        {
            dayCycle = false;
            winMarrow.SetActive(true);
            regMarrow.SetActive(false);
            dayTitle.GetComponent<Text>().text = "You Won!".ToString();
            marrowTitle.GetComponent<Text>().text = "Congrats! Your marrow won first place!".ToString();
            nextButton.SetActive(false);
            menuButton.SetActive(true);
            quitButton.SetActive(true);
        }

        //if day cycle is true, updates the day count, if conditions are met for it to be false it means that the end of the game was reached
        if (dayCycle == true)
        {
            dayTitle.GetComponent<Text>().text = "Day - " + GCInfo.dayNum.ToString();

        }

        //if the health reaches below 0 health cycle will turn false and the text sill show 0% rather than -17% for example
        if(healthPerCycle == true)
        {
            marrowHealth.GetComponent<Text>().text = GCInfo.marrowHealth + "%".ToString();
        }
        else
        {
            marrowHealth.GetComponent<Text>().text = "0%".ToString();
        }

    }
    public void showMoney()
    {
        moneyText.GetComponent<Text>().text = GCInfo.money.ToString();
    }
}
