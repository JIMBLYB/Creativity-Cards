using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barScript : MonoBehaviour
{
    [SerializeField]
    private float barFillAmount;

    [SerializeField]
    private Image barFill;

    public GameController GCInfo;


    void Start()
    {
        GCInfo = GameObject.FindWithTag("GameController").GetComponent<GameController>();

    }

    void Update()
    {
        //gets the marrow health and divides it by 100, so that its value can be transfered into the fillAmount
        healthBar();
        barFillAmount = GCInfo.marrowHealth;
        barFillAmount = barFillAmount / 100;
    }

    private void healthBar()
    {
        barFill.fillAmount = barFillAmount;
    }

}
