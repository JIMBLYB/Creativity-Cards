using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Initialises the enemies stats
    EnemyClass enemy = new EnemyClass();
    GameObject player;
    // Variables for controlling enemies actions
    public bool canAttack = false;
    bool movedTo = false;
    bool returning = false;

    Vector3 originalPos;
    
    void Start() 
    {
        player = GameObject.FindWithTag("Player");
        originalPos = transform.position;
        enemy.gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (canAttack)
        {
            doAttack();
        } 
    }

    public void doAttack()
    {
        if (!movedTo)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemy.movementSpeed * Time.deltaTime);
        }

        if (transform.position == player.transform.position)
        {
            movedTo = true;
            enemy.DecideAttack();
        }

        if (enemy.finishedAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, enemy.movementSpeed * Time.deltaTime);
        }

        if (transform.position == originalPos)
        {
            canAttack = false;
        }
        
    }
}
