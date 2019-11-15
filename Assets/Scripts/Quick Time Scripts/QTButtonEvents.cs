using UnityEngine;
using TMPro;
using System;

public class QTButtonEvents : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        KeyCode buttonKeyCode = (KeyCode)Enum.Parse(typeof(KeyCode), transform.GetComponentInChildren<TextMeshProUGUI>().text.ToString());

        if (Input.GetKeyDown(buttonKeyCode))
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}