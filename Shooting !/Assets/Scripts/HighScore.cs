using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start() 
    {
        text = GetComponent<Text>();
        if (Score.score == Score.highScore && Score.check)
        {
            text.text = "NEW HIGH SCORE: " + Score.highScore;
        }

        else
        {
            text.text = "Score: " + Score.score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
