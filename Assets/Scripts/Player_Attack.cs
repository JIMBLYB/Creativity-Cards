using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Vector3 destination;
    private Vector3 start_point;
    private bool  going;
    private bool returning;
    private bool moving;
    public float movement_speed;
    void Update()
    {
        //if left click is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //if the player isn't already moving
            if (!moving)
            {
                //find what the mouse has clicked on
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //if the mouse clicked on an object
                if (Physics.Raycast(ray, out hit))
                {

                    //if the object is an enemy
                    if (hit.transform.tag == "Enemy")
                    {
                        //finds where the player will have to move to to stand in front of the enemy
                        moving = true;
                        start_point = transform.position;
                        destination = hit.transform.position - transform.position;
                        if (hit.transform.position.x > transform.position.x)
                        {
                            destination.x -= 3.1f;
                        }
                        else
                        {
                            destination.x -= 0.1f;
                        }
                        going = true;
                    }

                }
            }
        }
        //if the player should be moving towards the enemy
        if(going)
        {
            //move the player towards the enemy
            transform.position = Vector3.MoveTowards(transform.position, destination, movement_speed);
            //if the player has arrived
            if (transform.position == destination)
            {
                //right now it only waits, but when attacks are coded in change this to an attack function
                StartCoroutine(attack_placeholder());
                going = false;
            }
        }
        //if the player should be going back to it's original position (after attacking)
        if (returning)
        {
            //move the player towards their original position
            transform.position = Vector3.MoveTowards(transform.position, start_point, movement_speed);
            //if they arrive
            if (transform.position == start_point)
            {
                //stop moving, can now move again. This will probably have to be altered when we implement turns.
                returning = false;
                moving = false;
            }
        }
    }
    //wait for one second, then the player returns to their start position
    IEnumerator attack_placeholder()
    {
        yield return new WaitForSeconds(1);
        returning = true;
    }
}
