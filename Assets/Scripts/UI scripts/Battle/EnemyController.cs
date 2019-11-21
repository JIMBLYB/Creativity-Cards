using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyClass enemy = new EnemyClass();
    GameObject player;

    bool canAttack = false;
    
    void Start() 
    {
        player = GameObject.FindWithTag("Player");
    }

    public void doAttack()
    {
        Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }
}
