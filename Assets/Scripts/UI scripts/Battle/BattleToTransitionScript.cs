using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleToTransitionScript : MonoBehaviour
{
    public GameController GCInfo;
    // Start is called before the first frame update
    void Start()
    {
        GCInfo = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        //put on battlescene, when there are no enemy tags left make battleend = true, loading transition slide
        if (GCInfo.battleEnd == true)
        {
            SceneManager.LoadScene(5);
            GCInfo.dayNum = GCInfo.dayNum + 1;
            GCInfo.battleEnd = false;
        }
    }
}
