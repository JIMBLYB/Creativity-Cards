using System.Collections;
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

        // Gets the player gameObject and PlayerAttack script for later use
        player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    void Start()
    {
        UpdateAttackSlots();
    }

    //when an attack button is pressed
    // public void OnAttackSelect(Button button)
    // {
    //     attackSelected = button;
    //     //if the player isn't already in the attack sequence
    //     if (!attacking)
    //     {
    //         //the player enters the attack sequence
    //         attacking = true;
    //     }
    // }

    public void OnAttackSelect(Button button)
    {
        // Sets the selected attack in PlayerAttackScript to the button pressed
        playerAttack.attackSelected = button.GetComponentInChildren<Text>().text;
    }

    // private void Update()
    // {
    //     if (attacking)
    //     {
    //         if (QTFramework.QTButtons.Count > 0)
    //         {
    //             quickTime = true;
    //         }
    //     }
    //     if (quickTime)
    //     {
    //         if (QTFramework.QTButtons.Count == 0)
    //         {
    //             player.GetComponent<PlayerAttack>().returning = true;
    //             quickTime = false;
    //         }
    //     }

    //     // QTFramework will only ever return a value between 0 and 1.
    //     // If a value has been returned by QTFramework prints QTResult.
    //     // This action is placeholder.
    //     // QTResult is then reset to two so this doesn't trigger continuously
    //     if (QTResult <= 1)
    //     {
    //         Debug.Log(QTResult);
    //         QTResult = 2;
    //     }
    // }

}
