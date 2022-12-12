using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnoughScore : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PayScoreHP.check)
        {
            if (PayScoreHP.full)
            {
                text.text = "FULL HP";
            }
            else
            {

                text.text = " ";
            }
        }
        else
        {
            text.text = "NOT ENOUGH SCORE";


        }
                
    }
}
