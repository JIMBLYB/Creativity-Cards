using UnityEngine;
using TMPro;
using System;

public class QTButtonEvents : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}