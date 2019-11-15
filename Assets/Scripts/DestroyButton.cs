using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("clash");
        Destroy(gameObject);
        Debug.Log("Kaboom");
    }
}
