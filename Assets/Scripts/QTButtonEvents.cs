using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTButtonEvents : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("clash");
        Destroy(gameObject);
        Debug.Log("Kaboom");
    }
}