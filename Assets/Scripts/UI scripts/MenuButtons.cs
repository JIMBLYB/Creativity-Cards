using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    // This method will define what happens when the user presses the start button.
    // It is intneded to be run from a UI component.
    public void PressStartButton()
    {
        SceneManager.LoadScene(1);
    }

    // This method will define what happens when the user clicks the help button.
    // It is intneded to be run from a UI component.
    public void PressHelpButton()
    {
        SceneManager.LoadScene(2);

    }

    // This method will define what happens when the user presses the quit button.
    // It is intneded to be run from a UI component.
    public void PressQuitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();

    }
    //Menu button on BattleScene
    public void PressMenuButton()
    {
        SceneManager.LoadScene(0);

    }
    //TeamSelect from ShopScene
    public void PressTeamButton()
    {
        SceneManager.LoadScene(3);

    }
    //Battlescene from TeamSelect
    public void PressBattleButton()
    {
        SceneManager.LoadScene(4);

    }
}
