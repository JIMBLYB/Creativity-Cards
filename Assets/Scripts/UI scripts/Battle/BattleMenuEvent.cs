﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Code is designed to sit in the 'Canvas - AttackScreen' in 'BattleScene' scene.
public class BattleMenuEvent : MonoBehaviour
{
    public bool attacking = false;
    private GameObject player;
    private PlayerAttack playerAttack;
    public Button attackSelected;
    private bool quickTime = false;
    // Float to hold how well the player did at the quick time event
    // Initialises to two to mark that it hasn't been set by QTFramework. 
    // QTFramework will only ever return a value between 0 and 1.
    public float QTResult = 2;

    // Function to set the text in the selected attack slots to be the same as what's stored in the gameController on load
    private void UpdateAttackSlots()
    {
        GameController gameController;
        Text[] selectedAttacks;

        // Gets the game controller for easier access
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        // Gets the text component in all of the selected attack buttons
        selectedAttacks = transform.GetComponentsInChildren<Text>();

        // Assigns the text in each button to the attacks stored in the gameController
        for (int i = 0; i < selectedAttacks.Length; i++)
        {
            selectedAttacks[i].text = gameController.selectedAttack[i];
        }
    }

    public void OnAttackSelect(Button button)
        {
        // Sets the selected attack in PlayerAttackScript to the button pressed
        string[] elements = button.GetComponentInChildren<Text>().text.Split(' ');
        playerAttack.attackSelected = elements[0];
        }


    void Start()
    {
        UpdateAttackSlots();
        // Gets the player gameObject and PlayerAttack script for later use
        player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        // QTFramework will only ever return a value between 0 and 1.
        // If a value has been returned by QTFramework prints QTResult.
        // This action is placeholder.
        // QTResult is then reset to two so this doesn't trigger continuously
        if (QTResult <= 1)
        {
            Debug.Log(QTResult);
            QTResult = 2;
        }
    }
}
