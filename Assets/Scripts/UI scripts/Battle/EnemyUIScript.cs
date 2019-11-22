using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIScript : MonoBehaviour
{
    private float barFillAmount;
    private Image barFill;
    private List<EnemyController> GCInfo;
    private List<Image> healthBars;

    private void GetEnemyControllers()
    {
        GCInfo = new List<EnemyController>();
        healthBars = new List<Image>();
    }

    void Start()
    {
        GCInfo = new List<EnemyController>();
        healthBars = new List<Image>();

        GameObject[] tempEnemyController = GameObject.FindGameObjectsWithTag("Enemy");
        Image[] tempHealthBars = transform.GetComponentsInChildren<Image>();

        for (int i = 0; i < tempHealthBars.Length; i++)
        {
            GCInfo.Add(tempEnemyController[i].GetComponent<EnemyController>());
            healthBars.Add(tempHealthBars[i]);
        }
    }

    void Update()
    {
        //gets the enemy health and divides it by 100, so that its value can be transfered into the fillAmount
        for (int i = 0; i < healthBars.Count; i++)
        {
            healthBars[i].fillAmount = (float)GCInfo[i].enemy.health / 10f;
        }
    }
}
