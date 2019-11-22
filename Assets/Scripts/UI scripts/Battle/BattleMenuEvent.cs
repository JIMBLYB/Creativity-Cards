using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private bool playersTurn;
    [SerializeField]
    private bool enemiesStartedAttack = false;
    // Lists to track all current enemies in the scene
    private List<EnemyController> enemyControllers;
    private List<GameObject> enemies;
    // Bool to track whether all enemies have been killed.
    private bool endScene = false;
    //gets game controller for logging the day number (didnt wanna edit the gamecontroller in UpdateAttackSlots incase I break it)
    public GameController GCInfo;

    // Function to set the text in the selected attack slots to be the same as what's stored in the gameController on load
    private void UpdateAttackSlots()
    {
        GameController gameController;
        Text[] selectedAttacks;

        // Gets the game controller for easier access
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        // Gets the text component in all of the selected attack buttons
        selectedAttacks = transform.GetChild(0).GetComponentsInChildren<Text>();

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

    private void GetEnemyControllers()
    {
        enemyControllers = new List<EnemyController>();
        enemies = new List<GameObject>();

        GameObject[] tempEnemyStore = GameObject.FindGameObjectsWithTag("Enemy");
        
        for (int i = 0; i < tempEnemyStore.Length; i++)
        {
            enemyControllers.Add(tempEnemyStore[i].GetComponent<EnemyController>());
            enemies.Add(tempEnemyStore[i]);
        }
    }

    void Start()
    {
        GCInfo = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        UpdateAttackSlots();
        // Gets the player gameObject and PlayerAttack script for later use
        player = GameObject.FindWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
        // Allows the player to go first.
        playersTurn = true;
        GetEnemyControllers();
    }

    void Update()
    {
        if (!endScene)
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
                    // Marks the players turn as over.
                    playersTurn = false;
                    QTResult = 2;
                    playerAttack.canAttack = false;
                }
            } 
            else
            {
                if (!enemiesStartedAttack)
                {
                    // Allows every enemy in the scene to begin their attacks.
                    for (int i = 0; i < enemyControllers.Count; i++)
                    {
                        // If the enemy has zero health they are removed from the scene.
                        if (enemyControllers[i].enemy.health <= 0)
                        {
                            Destroy(enemies[i]);
                            enemies.RemoveAt(i);
                            enemyControllers.RemoveAt(i);
                            // Decrements the counter as enemyControllers.Count has just been decremented.
                            i--;
                        }
                        else
                        {
                            enemyControllers[i].canAttack = true;
                        }
                    }
                    if (enemies.Count > 0)
                    {
                        enemiesStartedAttack = true;
                    }
                    else
                    {
                        endScene = true;
                    }
                }
                else
                {
                    // Assumes all enemies attacks have finished, then checks this.
                    // If any enemy hasn't finished their attacks, reverts the value of playerTurn and enemiesStartedAttack.
                    playersTurn = true;
                    enemiesStartedAttack = false;
                    for (int i = 0; i < enemyControllers.Count; i++)
                    {
                        if (enemyControllers[i].canAttack)
                        {
                            playersTurn = false;
                            enemiesStartedAttack = true;
                            break;
                        }
                    } 
                }  
            }        
        }
        else
        {
            Debug.Log("Enemies Killed");
            SceneManager.LoadScene(1);
            GCInfo.dayNum = GCInfo.dayNum + 1;
            GCInfo.health = 100;
        }
        if (GCInfo.health <= 0)
        {
            //if player health reaches zero, go to transition scene
            SceneManager.LoadScene(1);
            GCInfo.dayNum = GCInfo.dayNum + 1;
            GCInfo.marrowHealth = GCInfo.marrowHealth - 50;
            GCInfo.health = 100;
        }
    }
}
