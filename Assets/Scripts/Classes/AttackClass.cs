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
    
    public void LightAttack()
    {
        quickTimeKeys.Clear();
        quickTimeKeys.Add(KeyCode.L);
        quickTimeKeys.Add(KeyCode.I);
        quickTimeKeys.Add(KeyCode.G);
        quickTimeKeys.Add(KeyCode.H);
        quickTimeKeys.Add(KeyCode.T);
        StartQuickTime();
    }

    public void MediumAttack()
    {
        quickTimeKeys.Clear();
        quickTimeKeys.Add(KeyCode.M);
        quickTimeKeys.Add(KeyCode.E);
        quickTimeKeys.Add(KeyCode.D);
        quickTimeKeys.Add(KeyCode.I);
        quickTimeKeys.Add(KeyCode.U);
        quickTimeKeys.Add(KeyCode.M);
        StartQuickTime();
    }

    public void HeavyAttack()
    {
        quickTimeKeys.Clear();
        quickTimeKeys.Add(KeyCode.H);
        quickTimeKeys.Add(KeyCode.E);
        quickTimeKeys.Add(KeyCode.A);
        quickTimeKeys.Add(KeyCode.V);
        quickTimeKeys.Add(KeyCode.Y);
        StartQuickTime();
    }

    public void Sheep()
    {
        quickTimeKeys.Clear();
        quickTimeKeys.Add(KeyCode.S);
        quickTimeKeys.Add(KeyCode.H);
        quickTimeKeys.Add(KeyCode.E);
        quickTimeKeys.Add(KeyCode.E);
        quickTimeKeys.Add(KeyCode.P);
        StartQuickTime();
    }
}
