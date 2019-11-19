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
    
    // Script is incomplete, currently will always write an attack to the first attack slot.
    // When updating the game controller only the slot that was overwritten needs to be updated, not all of them.
    public void OnAttackClick(Button button)
    {
        // Gets the empty object all the team slots are stored under
        Transform teamSlots = transform.Find("Team Slots");

        // Gets all of the current text from the buttons in 'Team Slots' 
        Text[] selectedAttacks = teamSlots.GetComponentsInChildren<Text>();

        // Writes whatever is written on the button the user pressed to the first attack slot
        selectedAttacks[0].text = button.GetComponentInChildren<Text>().text;

        // Updates the game controller with all currently selected scripts
        for (int i = 0; i < 4; i++)
        {
            gameController.selectedAttack[i] = selectedAttacks[i].text;    
        }
            
    }
}
