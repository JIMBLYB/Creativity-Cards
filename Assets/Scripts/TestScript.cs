using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    public Object areaPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject QTArea = Instantiate(areaPrefab, transform.parent) as GameObject;
        List<KeyCode> sequence = new List<KeyCode>();
        sequence.Add((KeyCode)1);
        sequence.Add((KeyCode)2);
        sequence.Add((KeyCode)3);

        QTFramework QTFramework = QTArea.GetComponent<QTFramework>();
        QTFramework.sequence = sequence;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
