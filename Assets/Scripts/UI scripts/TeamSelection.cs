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
        Transform teamSlots = transform.Find("Team Slots");

        TMP_Text[] selectedAttacks = teamSlots.GetComponentsInChildren<TMP_Text>();

        Debug.Log(selectedAttacks[0]);
    }
}
