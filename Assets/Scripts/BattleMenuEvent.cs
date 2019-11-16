using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenuEvent : MonoBehaviour
{
    private List<KeyCode> quickTimeKeys = new List<KeyCode>();
    public Object areaPrefab;
    private void StartQuickTime()
    {
        GameObject QTArea = Instantiate(areaPrefab, transform.parent) as GameObject;

        QTFramework QTFramework = QTArea.GetComponent<QTFramework>();
        QTFramework.sequence = quickTimeKeys;
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
