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
    public List<KeyCode> sequence = new List<KeyCode>();
}
