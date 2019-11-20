using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Code is designed to sit in the 'Canvas - AttackScreen' in 'BattleScene' scene.
public class BattleMenuEvent : MonoBehaviour
{
    public Object areaPrefab;

    // Float to hold how well the player did at the quick time event
    // Initialises to two to mark that it hasn't been set by QTFramework. 
    // QTFramework will only ever return a value between 0 and 1.
    public float QTResult = 2;
    // Function to set the text in the selected attack slots to be the same as what's stored in the gameController on load
    public void OnAttackSelect(Button button)
    {
        // Initialises the sequence to pass to QTFramework.
        // Is initialised as a new list to prevent crashing on unknown attack
        List<KeyCode> quickTimeKeys = new List<KeyCode>();
        // Instantiates the area that the quick time event will occur in as a child of the canvas.
        GameObject QTArea = Instantiate(areaPrefab, transform) as GameObject;

        QTFramework QTFramework = QTArea.GetComponentInChildren<QTFramework>();

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
    }

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
