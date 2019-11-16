using System.Collections.Generic;
using UnityEngine;

using TMPro;

// Quick time event handler.
// Code from https://gist.github.com/grimmdev/b85994d1b7cad444eb69 has been used as inspiration.

// This class has been designed to be added to a game object which defines the area you want the quick time event to occur in. 
// The function runQTEvent should then be called whenever a quick time event should run and must be passed the sequence of key presses to display

public class QTFramework : MonoBehaviour
{
    // Stores the keys in the quick time event sequence.
    // This should be passed to the framework
    public List<KeyCode> sequence;

    public int buttonOffset = 5;
    public int keySpeed = 1;
    public GameObject buttonPrefab;
    private RectTransform QTArea;
    private List<GameObject> QTButtons = new List<GameObject>();
    private List<bool> buttonEnteredArea = new List<bool>();    

    private void GenerateButtons()
    {
        if (sequence != null)
        {
            // Sets y and z positions of the buttons as they will remain constant
            Vector3 buttonPos = new Vector3();
            buttonPos.y = QTArea.position.y;
            buttonPos.z = QTArea.position.z;

            // Gets the width of the buttons so they can be instanced without overlapping
            RectTransform buttonTransform = buttonPrefab.GetComponent<RectTransform>();
            float buttonWidth = buttonTransform.sizeDelta.x;

            // Spawns all of the quick time buttons for the sequence
            for (int i = 0; i < sequence.Count; i++)
            {
                // Sets the position of the button to the right of the previous button
                buttonPos.x = QTArea.position.x + buttonOffset * (i + 1) + buttonWidth * i;
                // Instances a button at the new position as a child of the QTArea transform
                // 'as GameObject' means button is instanced as a GameObject rather than an Object
                QTButtons.Add(Instantiate(buttonPrefab, buttonPos, new Quaternion(), transform) as GameObject);

                // Gets the text component of the button and sets it to the buttons keycode
                TextMeshProUGUI buttonText = QTButtons[i].transform.GetComponentInChildren<TextMeshProUGUI>();
                buttonText.text = sequence[i].ToString();
            }
        }
    }

    private void RemoveListItems(int i)
    {
        QTButtons.RemoveAt(i);
        sequence.RemoveAt(i);
        buttonEnteredArea.RemoveAt(i);
    }

    void Start()
    {
        // Gets the area the quick time event is happening in and uses it for refrence when placing the buttons. 
        QTArea = transform.parent.GetComponent<RectTransform>();

        // Generates quick time buttons
        GenerateButtons();
    }

    void Update()
    {
        if (buttonEnteredArea.Count != 0)
        {
            if (Input.GetKeyDown(sequence[0]) && buttonEnteredArea[0])
            {
                Destroy(QTButtons[0]);
                RemoveListItems(0);
            }
        }
        

        // Checks if any buttons have been deleted, then removes it from the list
        for (int i = 0; i < QTButtons.Count; i++)
        {
            if (QTButtons[i] == null)
            {
                RemoveListItems(i);
            }
        }

        // Destroys QTArea once quick time event is finsihed.
        // This is placeholder.
        if (QTButtons.Count == 0)
        {
            Destroy(transform.parent.gameObject);
        }

        // Moves the buttons to the left at a speed defined by keySpeed
        for (int i = 0; i < QTButtons.Count; i++)
        {
            QTButtons[i].transform.position -= new Vector3(keySpeed * Time.deltaTime, 0, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        buttonEnteredArea.Add(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
