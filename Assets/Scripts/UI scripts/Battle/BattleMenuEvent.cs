using UnityEngine;
using UnityEngine.UI;

// Code is designed to sit in the 'Canvas - AttackScreen' in 'BattleScene' scene.
public class BattleMenuEvent : MonoBehaviour
{
    private GameObject player;
    private PlayerAttack playerAttack;
    public Button attackSelected;
    // Float to hold how well the player did at the quick time event
    // Initialises to two to mark that it hasn't been set by QTFramework. 
    // QTFramework will only ever return a value between 0 and 1.
    public float QTResult = 2;
    // Stores the enemy the player is currently attacking
    public GameObject targetedEnemy = null;
    // A bool to denote whether it is the players turn or the enemies.
    private bool playersTurn = true;
    private bool enemiesStartedAttack = false;
    private GameObject[] enemies;

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
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }

    void Update()
    {
        // QTFramework will only ever return a value between 0 and 1.
        // If a value has been returned by QTFramework prints QTResult.
        // This action is placeholder.
        // QTResult is then reset to two so this doesn't trigger continuously
        if (playersTurn)
        {
            playerAttack.canAttack = true;
            
            if (QTResult <= 1)
            {
                //Debug.Log(QTResult);

                // Targeted enemy takes 10 * QTResult amount of damage.
                // This is placeholder, each attack should have its own damage values.
                targetedEnemy.GetComponent<EnemyController>().enemy.health -= (int)(10 * QTResult);
                // Prints enemies current health after taking damage.
                Debug.Log(targetedEnemy.GetComponent<EnemyController>().enemy.health);
                targetedEnemy = null;
                QTResult = 2;
                // Marks the players turn as over.
                playerAttack.canAttack = false;
                playersTurn = false;
            }
        } 
        else 
        {
            if (!enemiesStartedAttack)
            {
                // Allows every enemy in the scene to begin their attacks.
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<EnemyController>().canAttack = true;
                }
                enemiesStartedAttack = true;
            }
            else
            {
                // Assumes all enemies attacks have finished, then checks this.
                // If any enemy hasn't finished their attacks, reverts the value of playerTurn and enemiesStartedAttack.
                playersTurn = true;
                enemiesStartedAttack = false;
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i].GetComponent<EnemyController>().canAttack)
                    {
                        playersTurn = false;
                        enemiesStartedAttack = true;
                        break;
                    }
                } 
            }  
        }        
    }
}
