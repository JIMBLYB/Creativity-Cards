using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TeamSelection : MonoBehaviour
{
    // Script is designed to sit in 'Canvas - TeamSelect' in the 'TeamSelect' scene

    GameController gameController;
    // Fetches the GameController for later use
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }
    

    public void OnAttackClick(Button button)
    {
        Transform teamSlots = transform.Find("Team Slots");

        Text[] selectedAttacks = teamSlots.GetComponentsInChildren<Text>();

        selectedAttacks[0].text = button.GetComponentInChildren<Text>().text;

        for (int i = 0; i < 4; i++)
        {
            gameController.selectedAttack[i] = selectedAttacks[i].text;    
        }
            
    }
}
