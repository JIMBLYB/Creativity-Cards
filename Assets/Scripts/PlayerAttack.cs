using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Vector3 destination;
    private Vector3 start_point;
    private bool going;
    private bool returning;
    private bool moving;
    private GameObject targeted_enemy;
    private object selected_attack;
    void Update()
    {
        //IF AN ATTACK IS SELECTED IN THE UI
        //selected_attack = the attack that was selected
        if (Input.GetMouseButtonDown(0))
        {
            if (!moving)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        targeted_enemy = hit.transform.gameObject;
                        moving = true;
                        start_point = transform.position;
                        destination = hit.transform.position;                   
                        destination = destination * 0.9f;
                        going = true;
                    }

                }
            }
        }

        if (going)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.2f);
            if (transform.position == destination)
            {
                going = false;
                //PLAY ANIMATION
                if (Random.Range(0.0f, 100.0f) < gameObject.GetComponent<AttackClass>().accuracy)
                {
                    targeted_enemy.GetComponent<EnemyClass>().health -= gameObject.GetComponent<AttackClass>().damage;
                    //DISPLAY DAMAGE NUMBERS IN UI
                }
                else
                {
                    //DISPLAY MISS MESSAGE IN UI
                }
                returning = true;
            }
        }

        if (returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, start_point, 0.2f);
            if (transform.position == start_point)
            {
                returning = false;
                moving = false;
            }
        }
    }
}
