using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Vector3 destination;
    private Vector3 start_point;
    private bool going = false;
    public bool returning = false;
    private object selected_attack;
    public GameObject Battle_UI;
    void Update()
    {
        //checks if an attack button has been pressed
        if (Battle_UI.GetComponent<BattleMenuEvent>().attacking)
        {
            //checks if you click on an enemy
            if (Input.GetMouseButtonDown(0))
            {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == "Enemy")
                        {
                        //records where the player is originally, to return to after attacking
                            start_point = transform.position;
                        //finds where the player will have to move to reach the enemy
                            destination = hit.transform.position;
                            if (destination.x > transform.position.x)
                            {
                            destination.x -= 1;
                            }
                            else
                            {
                            destination.x += 1;
                            }
                        //sets the player as moving towards an enemy
                            going = true;
                        }

                    }
            }

            if (going)
            {
                //moves the player towards the selected enemy
                transform.position = Vector3.MoveTowards(transform.position, destination, 0.2f);
                //checks if the player has reached the enemy
                if (transform.position == destination)
                {
                    //stops the player moving
                    going = false;
                    //starts the quicktime event
                    Battle_UI.GetComponent<BattleMenuEvent>().Attacking(Battle_UI.GetComponent<BattleMenuEvent>().selected_button);
                }
            }
            //if the quick time event has finished
            else if (returning)
            {
                //moves the player towards where it started
                transform.position = Vector3.MoveTowards(transform.position, start_point, 0.2f);
                //checks if the player has arrived back
                if (transform.position == start_point)
                {
                    //stops the attack sequence, allowing another attack
                    Battle_UI.GetComponent<BattleMenuEvent>().attacking = false;
                    //resets the attack sequence
                    returning = false;
                }
            }
        }
    }
}
