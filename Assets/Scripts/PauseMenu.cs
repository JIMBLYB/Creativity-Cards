using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //I used Brackeys tutorial to do this script
    public static bool PausedGame = false;
    public GameObject PauseUI;

    void Start()
    {
        PauseUI.SetActive(false);
        PausedGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting player input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //resumes game
            if (PausedGame == true)
            {
                Resume();
            }
            //pauses game
            else
            {
                Pause();
            }
        }
    }
    //sets time to 0, resuming game and disabling overlay
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        PausedGame = false;
    }
    //sets time to 1, pausing game and enables overlay
    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        PausedGame = true;
    }
}
