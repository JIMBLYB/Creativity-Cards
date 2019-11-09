using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quick time event handler.
// Code from https://gist.github.com/grimmdev/b85994d1b7cad444eb69 has been used as inspiration.

public class QTFramework : MonoBehaviour
{
    private enum CurrentState 
    {
        Ready,
        Active,
        Completed
    };

    private CurrentState QTState = CurrentState.Ready;

    private enum Response
    {
        Null,
        Success,
        Fail
    };

    private Response QTResponse = Response.Null;

    // Stores the keys in the quick time event sequence.
    // This should be passed to the framework
    private List<KeyCode> sequence = new List<KeyCode>();

    public GameObject displaySpace;
    public int displayOffset = 5;
    public int keySpeed = 1;

    public QTFramework(GameObject displaySpace)
    {

    }

    public void runQTEvent(List<KeyCode> sequence)
    {
        void Start()
        {
            
        }

        void Update()
        {

        }
    }
}
