using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Class : MonoBehaviour
{
    public string attack_name;
    public int cooldown, ID, damage;
    public float accuracy;
    public List<KeyCode> attackSequence;
}
