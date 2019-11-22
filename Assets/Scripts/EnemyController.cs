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
    private bool going = false;
    private bool attacking = false;
    private Vector3 originalPos;
    Animator Animator;
    AudioSource AudioSource;
    public AudioClip SoundFX;

    void Start() 
    {
        player = GameObject.FindWithTag("Player");
        originalPos = transform.position;
        enemy.gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        Animator = gameObject.GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Will only attack if it's been given permission by 'BattleMenuEvent' script.
        if (canAttack && !attacking)
        {
            attacking = true;
            Animator.SetTrigger("Attack");
            going = true;
        }
        if (going)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemy.movementSpeed * Time.deltaTime);
            if (transform.position == player.transform.position)
            {
                going = false;
                enemy.DecideAttack();
                AudioSource.PlayOneShot(SoundFX);
            }
        }
        if (enemy.finishedAttack && canAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, enemy.movementSpeed * Time.deltaTime);
            if (transform.position == originalPos)
            {
                Animator.SetTrigger("Attack");
                canAttack = false;
                enemy.finishedAttack = false;
            }
        }
    }
}
