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

    private void UpdateAttackSlots()
    {
        int i = 0;
        do
        {
            // If there is no attack stored in the gameController sets all remaining attack slots to empty.
            // Else sets the attack slot to the attack in the gameController
            if (string.IsNullOrEmpty(gameController.selectedAttack[i]))
            {
                for (i = i; i < selectedAttacks.Length; i++)
                {
                    selectedAttacks[i].text = string.Empty;
                }
            } 
            else 
            {
                selectedAttacks[i].text = gameController.selectedAttack[i];
                i++;
            }
                
        } while (i < selectedAttacks.Length);
    }
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        // Gets the empty object all the team slots are stored under
        teamSlots = transform.Find("Team Slots");
        // Gets all of the current text from the buttons in 'Team Slots' 
        selectedAttacks = teamSlots.GetComponentsInChildren<Text>();

        // Sets the attack slot buttons to what's currently stored in the gameController
        UpdateAttackSlots();
    }
    
    public void OnAttackClick(Button button)
    {
        bool assignedAttack = false;
        int i = 0;

        // Updates the first empty selected attack, or the last one if none are free
        do
        {
            if (string.IsNullOrEmpty(gameController.selectedAttack[i]) || (selectedAttacks[i].text == button.GetComponentInChildren<Text>().text ^ i == 4))
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
            if (string.IsNullOrEmpty(gameController.selectedAttack[i]))
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
            StartCoroutine(DisplayError());
        }
    }
}
