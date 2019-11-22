using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Initialises the enemies stats
    public EnemyClass enemy = new EnemyClass();
    private GameObject player;
    // Variables for controlling enemies actions
    public bool canAttack = false;
    [SerializeField]
    private bool movedTo = false;
    private Vector3 originalPos;
    Animator Animator;
    
    void Start() 
    {
        player = GameObject.FindWithTag("Player");
        originalPos = transform.position;
        enemy.gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Will only attack if it's been given permission by 'BattleMenuEvent' script.
        if (canAttack)
        {
            doAttack();
            Animator.SetTrigger("Attack");
        } 
    }

    public void doAttack()
    {
        // If the enemy hasn't completed its move to the player then moves closer.
        if (!movedTo)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemy.movementSpeed * Time.deltaTime);
        }
        // Once the enemy has reached the player they do their attack.
        if (transform.position == player.transform.position)
        {
            movedTo = true;
            enemy.DecideAttack();
        }
        // Once the enemy has finished the attack it returns to its starting position.
        if (enemy.finishedAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, enemy.movementSpeed * Time.deltaTime);
        }
        // Once it reaches its start position it resets bool variables.
        if (transform.position == originalPos)
        {
            canAttack = false;
            movedTo = false;
            enemy.finishedAttack = false;
        }
        
    }
}
