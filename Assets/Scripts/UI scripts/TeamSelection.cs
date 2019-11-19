using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class TeamSelection : MonoBehaviour
{
    // Script is designed to sit in 'Canvas - TeamSelect' in the 'TeamSelect' scene

    public void OnAttackClick(Button button)
    {
        Debug.Log("cake");
        Transform teamSlots = transform.Find("Team Slots");

        Text[] selectedAttacks = teamSlots.GetComponentsInChildren<Text>();

        
    }
}
