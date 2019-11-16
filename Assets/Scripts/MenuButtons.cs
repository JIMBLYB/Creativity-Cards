// This script just contains functions that get called from clicking on buttons using Unity's UI system.
// Put this script on an object in the scene and use the event properties of the UI components to run the desired method.
// Any method set as "public void" on any script in the scene can be run by the UI event system.
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.UI; // If we are accessing UI components (eg Text, Button, Slider etc.) you need to use this library.

public class MenuButtons : MonoBehaviour {

    // This method will define what happens when the user presses the start button.
    // It is intneded to be run from a UI component.
    public void PressStartButton()
    {
        Debug.Log("Start button pressed.");

        SceneManager.LoadScene(1);
    }

    // This method will define what happens when the user clicks the help button.
    // It is intneded to be run from a UI component.
    public void PressHelpButton()
    {
        Debug.Log("Help button pressed.");
        // Add tutorial scene here using //SceneManager.LoadScene(2);

    }

    // This method will define what happens when the user presses the quit button.
    // It is intneded to be run from a UI component.
    public void PressQuitButton()
    {
        Debug.Log("Quit button pressed.");

        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

    }
    //Resume button on BattleScene
    public void PressResumeButton()
    {
        Debug.Log("Resume button pressed.");

    }
    //Menu button on BattleScene
    public void PressMenuButton()
    {
        Debug.Log("Menu button pressed.");

        SceneManager.LoadScene(0);

    }
    // NB You could use the same process in the worksheet to extend the functionality of the quit button by adding a quit confirmation panel.
    // The script will need to know the game object that holds the quit confirmation elements.
    // We could add the methods here and hook them up to buttons in the same way.
}
