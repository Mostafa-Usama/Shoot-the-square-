using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int kills = 0;
    public static int combo = 1;
    public static int score = 0;
    public static int highScore = 0;
    public Text text;
    public static bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
        text.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score >  highScore)
        {
            check = true;
            highScore = score;
        }
        if (combo >= 32)
        {
            combo = 32;
        }

        text.text = "Score: " + score + "\nCombo: " + combo;
       
            
        

    }

}
