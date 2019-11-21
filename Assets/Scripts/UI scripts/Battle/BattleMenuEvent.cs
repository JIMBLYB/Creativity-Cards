using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Code is designed to sit in the 'Canvas - AttackScreen' in 'BattleScene' scene.
public class BattleMenuEvent : MonoBehaviour
{
    public Object areaPrefab;
    public bool attacking;
    public GameObject player;
    public Button selected_button;
    QTFramework QTFramework;
    private bool quickTime = false;

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

    void Start()
    {
        UpdateAttackSlots();
        attacking = false;
    }

    //when an attack button is pressed
    public void OnAttackSelect(Button button)
    {
        selected_button = button;
        //if the player isn't already in the attack sequence
        if (!attacking)
        {
            //the player enters the attack sequence
            attacking = true;
        }
    }

    //This manages the quicktime events
    public void Attacking(Button button)
    {
        // Initialises the sequence to pass to QTFramework.
        // Is initialised as a new list to prevent crashing on unknown attack
        List<KeyCode> quickTimeKeys = new List<KeyCode>();
        // Instantiates the area that the quick time event will occur in as a child of the canvas.
        GameObject QTArea = Instantiate(areaPrefab, transform) as GameObject;
        QTFramework = QTArea.GetComponentInChildren<QTFramework>();
        // Checks which attack was selected and then sets the quick time button sequence accordingly.
        // Currently uses placeholder sequences
        string selectedAttack = button.GetComponentInChildren<Text>().text;       
            switch (selectedAttack)
            {
                case "Light":
                    {
                        quickTimeKeys = new List<KeyCode>
                {
                    KeyCode.L,
                    KeyCode.I,
                    KeyCode.G,
                    KeyCode.H,
                    KeyCode.T
                };
                        break;
                    }
                case "Medium":
                    {
                        quickTimeKeys = new List<KeyCode>
                {
                    KeyCode.M,
                    KeyCode.E,
                    KeyCode.D,
                    KeyCode.I,
                    KeyCode.U
                };
                        break;
                    }
                case "Heavy":
                    {
                        quickTimeKeys = new List<KeyCode>
                {
                    KeyCode.H,
                    KeyCode.E,
                    KeyCode.A,
                    KeyCode.V,
                    KeyCode.Y
                };
                        break;
                    }
                case "Sheep":
                    {
                        quickTimeKeys = new List<KeyCode>
                {
                    KeyCode.S,
                    KeyCode.H,
                    KeyCode.E,
                    KeyCode.E,
                    KeyCode.P
                };
                        break;
                    }
                default:
                    Debug.Log("ERROR: Unkown attack");
                    break;
            }
            // Sends the selected sequence to the quick time area
            QTFramework.sequence = quickTimeKeys;
        //the quick time event has ended, tells the player to go back   
    }
    private void Update()
    {
        if (attacking)
        {
            if (QTFramework.QTButtons.Count > 0)
            {
                quickTime = true;
            }
        }
        if (quickTime)
        {
            if (QTFramework.QTButtons.Count == 0)
            {
                player.GetComponent<PlayerAttack>().returning = true;
                quickTime = false;
            }
        }
    }

}
