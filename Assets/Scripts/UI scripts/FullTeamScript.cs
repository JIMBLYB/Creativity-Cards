using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FullTeamScript : MonoBehaviour
{
    public int teamMemberNum;
    public GameObject NETMText;
    public Button nextButtonClick;

    void Start()
    {
        NETMText.SetActive(false);

        Button nxbtn = nextButtonClick.GetComponent<Button>();
        nxbtn.onClick.AddListener(nextButtonClicked);
    }

    void nextButtonClicked()
    {
        if(teamMemberNum == 4)
        {
            //Battlescene from TeamSelect
            SceneManager.LoadScene(4);
        }
        else
        {
            notEnoughTeamMembers();
        }
    }
    public void notEnoughTeamMembers()
    {
        NETMText.SetActive(true);
        //activates timer
        StartCoroutine(timerNETMText());
    }

    //NETM timer
    IEnumerator timerNETMText()
    {
        yield return new WaitForSeconds(0.85f);
        //when timer finishes disables text
        NETMText.SetActive(false);
    }
}
