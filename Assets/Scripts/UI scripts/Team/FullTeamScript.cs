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
    public Button lightButton, mediumButton, heavyButton, sheepButton;
    public GameObject slot1, slot2, slot3, slot4;
    List<string> attackList = new List<string>();

    void Start()
    {
        //not enough team members
        NETMText.SetActive(false);
        //next button
        Button nxbtn = nextButtonClick.GetComponent<Button>();
        nxbtn.onClick.AddListener(nextButtonClicked);

        //attack buttons
        Button ligbtn = lightButton.GetComponent<Button>();
        Button medbtn = mediumButton.GetComponent<Button>();
        Button hevbtn = heavyButton.GetComponent<Button>();
        Button shebtn = sheepButton.GetComponent<Button>();

        ligbtn.onClick.AddListener(lightClicked);
        medbtn.onClick.AddListener(mediumClicked);
        hevbtn.onClick.AddListener(heavyClicked);
        shebtn.onClick.AddListener(sheepClicked);
    }

    void Update()
    { // counting the amount in the array
        teamMemberNum = (attackList.Count);

        //if (teamMemberNum >= 1)
       // {
            //slot1.GetComponent<Text>().text = attackList[1].ToString();
        //    print(attackList[1]);
        //}
        //slot2.GetComponent<Text>().text = attackList[2].ToString();
        //slot3.GetComponent<Text>().text = attackList[3].ToString();
        //slot4.GetComponent<Text>().text = attackList[4].ToString();
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

    //Testing if attack gets selected
    void lightClicked()
    {
        if (teamMemberNum <= 3)
        {
            attackList.Add("Light");
        }
        else
        {
            Debug.Log("Team is full");
        }
    }
    void mediumClicked()
    {
        if (teamMemberNum <= 3)
        {
            attackList.Add("Medium");
        }
        else
        {
            Debug.Log("Team is full");
        }
    }
    void heavyClicked()
    {
        if (teamMemberNum <= 3)
        {
            attackList.Add("Heavy");
        }
        else
        {
            Debug.Log("Team is full");
        }
    }
    void sheepClicked()
    {
        if (teamMemberNum <= 3)
        {
            attackList.Add("Sheep");
        }
        else
        {
            Debug.Log("Team is full");
        }
    }

    //NETM timer
    IEnumerator timerNETMText()
    {
        yield return new WaitForSeconds(0.85f);
        //when timer finishes disables text
        NETMText.SetActive(false);
    }
}
