using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private GameObject targetedEnemy;
    private Vector3 originalPos;
    private Vector3 targetedPos;
    public string attackSelected = string.Empty;
    [SerializeField]
    private bool going = false;
    [SerializeField]
    private bool returning = false;
    [SerializeField]
    private bool attacking;
    private GameObject rootUI;
    public Object areaPrefab;
    private QTFramework QTFramework;
    private BattleMenuEvent battleMenuEvent;
    Animator Animator;
    AudioSource AudioSource;
    public AudioClip SoundFX;
    public GameObject gameController;
    public List<GameObject> enemies;

    public float movementSpeed = 5.0f;
    // Bool to denote whether the player can attack or not.
    public bool canAttack = false;

    public void RunQuickTime(string attack)
    {
        
        // Initialises the sequence to pass to QTFramework.
        // Is initialised as a new list to prevent crashing on unknown attack
        List<KeyCode> quickTimeKeys = new List<KeyCode>();
        // Instantiates the area that the quick time event will occur in as a child of the canvas.
        GameObject QTArea = Instantiate(areaPrefab, rootUI.transform) as GameObject;
        QTFramework = QTArea.GetComponentInChildren<QTFramework>();
        // Checks which attack was selected and then sets the quick time button sequence accordingly.
        // Currently uses placeholder sequences 
            switch (attack)
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
                        KeyCode.U,
                        KeyCode.M
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
                {
                    Debug.Log("ERROR: Unkown attack \n" + attack);
                    break;
                }        
            }
            // Sends the selected sequence to the quick time area
            QTFramework.sequence = quickTimeKeys;    
    }

    void Start()
    {
        // Gets the canvas all other canvas' are children of and stores it as rootUI.
        // Gets the BattleMenuEvent component from the rootUI.
        rootUI = GameObject.FindWithTag("RootUI");
        battleMenuEvent = rootUI.GetComponent<BattleMenuEvent>();
        Animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();

        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameController.GetComponent<GameController>().turns.Add(gameObject);
        foreach (var enemy in enemies)
        {
            gameController.GetComponent<GameController>().turns.Add(enemy);
        }
    }

    void Update()
    {
        //checks if an attack button has been pressed
        if (canAttack && !attacking && !string.IsNullOrEmpty(attackSelected) && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
            {
                attacking = true;
                //records where the player is originally, to return to after attacking
                originalPos = transform.position;
                //finds where the player will have to move to reach the enemy
                targetedEnemy = hit.transform.gameObject;
                targetedPos = targetedEnemy.transform.position;
                // Offsets the target position to stop the player clipping into the enemy.
                if (targetedPos.x > transform.position.x)
                {
                    targetedPos.x -= 1;
                }
                else
                {
                    targetedPos.x += 1;
                }
                //sets the player as moving towards an enemy
                going = true;
                Animator.SetTrigger("Move");

            }
        }

        if (going)
        {
            //moves the player towards the selected enemy
            transform.position = Vector3.MoveTowards(transform.position, targetedPos, movementSpeed * Time.deltaTime);
            //checks if the player has reached the enemy
            if (transform.position == targetedPos)
            {
                //stops the player moving
                going = false;
                Animator.SetTrigger("Attack");
                AudioSource.PlayOneShot(SoundFX);
                //starts the quicktime event
                RunQuickTime(attackSelected);
            }
        }
        // QTResult will only be less than two once the quick time event has finished and returned the results
        else if (rootUI.GetComponent<BattleMenuEvent>().QTResult < 2)
        {
            returning = true;
            Animator.SetTrigger("Move");
            battleMenuEvent.targetedEnemy = targetedEnemy;
        }

        if (returning)
        {
            //moves the player towards where it started
            transform.position = Vector3.MoveTowards(transform.position, originalPos, movementSpeed * Time.deltaTime);
            //checks if the player has arrived back
            if (transform.position == originalPos)
            {
                //stops the attack sequence, allowing another attack
                //resets the attack sequence
                attacking = false;
                returning = false;
                canAttack = false;
                Animator.SetTrigger("Move");
                gameController.GetComponent<GameController>().TurnSwap();
            }
        }        
    }
}