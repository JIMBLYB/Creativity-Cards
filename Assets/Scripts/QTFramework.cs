using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Quick time event handler.
// Code from https://gist.github.com/grimmdev/b85994d1b7cad444eb69 has been used as inspiration.

// This class has been designed to be added to a game object which defines the area you want the quick time event to occur in. 
// The function runQTEvent should then be called whenever a quick time event should run and must be passed the sequence of key presses to display

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

    public int displayOffset = 5;
    public int keySpeed = 1;
    public Object buttonPreFab;

    public static void runQTEvent(List<KeyCode> sequence)
    {
        void Start()
        {
            
        }

        void Update()
        {

        }
    }
}
