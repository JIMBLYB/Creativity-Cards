using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Vector3 destination;
    private Vector3 start_point;
    private bool going = false;
    public bool arrived = false;
    private bool returning = false;
    private GameObject targeted_enemy;
    private object selected_attack;
    public GameObject Battle_UI;
    void Update()
    {
        if (Battle_UI.GetComponent<BattleMenuEvent>().attacking)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("clicked");
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("hit");
                        if (hit.transform.tag == "Enemy")
                        {
                            Debug.Log("Enemy");
                            targeted_enemy = hit.transform.gameObject;
                            start_point = transform.position;
                            destination = hit.transform.position;
                            destination = destination * 0.9f;
                            going = true;
                        }

                    }
            }

            if (going)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, 0.2f);
                if (transform.position == destination)
                {
                    Debug.Log("arrived");
                    going = false;
                    arrived = true;
                    returning = true;
                }
            }
            else if (!arrived && returning)
            {
                Debug.Log("returning");
                transform.position = Vector3.MoveTowards(transform.position, start_point, 0.2f);
                if (transform.position == start_point)
                {
                    Battle_UI.GetComponent<BattleMenuEvent>().attacking = false;
                }
            }
        }
    }
}
