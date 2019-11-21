using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private Vector3 targetedEnemy;
    private Vector3 originalPos;
    public string attackSelected = string.Empty;
    private bool going = false;
    public bool returning = false;
    private bool attacking;
    private GameObject rootUI;
    public Object areaPrefab;
    QTFramework QTFramework;

    public float movementSpeed = 5.0f;

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
        rootUI = GameObject.FindWithTag("RootUI");
    }

    void Update()
    {
        //checks if an attack button has been pressed
        if (!attacking && !string.IsNullOrEmpty(attackSelected) && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy")
            {
                attacking = true;
                //records where the player is originally, to return to after attacking
                originalPos = transform.position;
                //finds where the player will have to move to reach the enemy
                targetedEnemy = hit.transform.position;
                // Offsets the target position to stop the player clipping into the enemy.
                if (targetedEnemy.x > transform.position.x)
                {
                    targetedEnemy.x -= 1;
                }
                else
                {
                    targetedEnemy.x += 1;
                }
                //sets the player as moving towards an enemy
                going = true;

            }
        }

        if (going)
        {
            //moves the player towards the selected enemy
            transform.position = Vector3.MoveTowards(transform.position, targetedEnemy, movementSpeed * Time.deltaTime);
            //checks if the player has reached the enemy
            if (transform.position == targetedEnemy)
            {
                //stops the player moving
                going = false;
                //starts the quicktime event
                RunQuickTime(attackSelected);
            }
        }
        // QTResult will only be less than two once the quick time event has finished and returned the results
        else if (rootUI.GetComponent<BattleMenuEvent>().QTResult < 2)
        {
            // Should be replaced by a function call
            returning = true;
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
            }
        }        
    }
}