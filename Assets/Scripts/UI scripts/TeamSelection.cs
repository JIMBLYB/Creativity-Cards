using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TeamSelection : MonoBehaviour
{
    // Script is designed to sit in 'Canvas - TeamSelect' in the 'TeamSelect' scene

    public GameObject errorMessage;
    GameController gameController;
    Transform teamSlots;
    Text[] selectedAttacks;
    // Fetches the GameController for later use
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        // Gets the empty object all the team slots are stored under
        teamSlots = transform.Find("Team Slots");
        // Gets all of the current text from the buttons in 'Team Slots' 
        selectedAttacks = teamSlots.GetComponentsInChildren<Text>();
    }
    
    public void OnAttackClick(Button button)
    {
        bool assignedAttack = false;
        int i = 0;

        // Updates the first empty selected attack, or the last one if none are free
        do
        {
            if (String.IsNullOrEmpty(gameController.selectedAttack[i]) || (selectedAttacks[i].text == button.GetComponentInChildren<Text>().text ^ i == 4))
            {
                selectedAttacks[i].text = button.GetComponentInChildren<Text>().text;
                gameController.selectedAttack[i] = selectedAttacks[i].text;
                assignedAttack = true;
            }

            i++;
        } while (!assignedAttack);      
    }

    // When a slot is pressed clears it and updates the gamecontroller
    public void OnSlotClick(Button button)
    {
        int buttonIndex = button.transform.GetSiblingIndex();

        // Sets the text on the button to empty and updates gamecontroller
        button.GetComponentInChildren<Text>().text = string.Empty;
        gameController.selectedAttack[buttonIndex] = string.Empty;
    }

    // Displays an error at the top of the screen if the user tries to continue with less than 4 attacks
    IEnumerator DisplayError()
    {
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(0.85f);
        errorMessage.SetActive(false);
    }

    public void NextButtonClicked()
    {
        bool allAttacks = true;

        for (int i = 0; i < gameController.selectedAttack.Length; i++)
        {   
            if (String.IsNullOrEmpty(gameController.selectedAttack[i]))
            {
                allAttacks = false;
                break;
            }
        }

        if (allAttacks)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            DisplayError();
        }
    }
}
