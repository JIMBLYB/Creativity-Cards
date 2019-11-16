using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClass : MonoBehaviour
{
    public string attack_name;
    public int cooldown, ID, damage;
    public float accuracy;
    public List<KeyCode> attackSequence = new List<KeyCode>();
    public Object QTAreaPrefab;

    // Placeholder for testing purposes
    void Start()
    {
        attackSequence.Add(KeyCode.A);
        attackSequence.Add(KeyCode.B);
        attackSequence.Add(KeyCode.C);
    }

    // Instantiates and begins the quick time event
    public void OnButtonPress()
    {
        GameObject QTArea = Instantiate(QTAreaPrefab, transform.parent) as GameObject;

        QTFramework QTFramework = QTArea.GetComponentInChildren<QTFramework>();
        QTFramework.sequence = attackSequence;
    }
}
