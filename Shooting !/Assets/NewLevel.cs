using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public GameObject panel;
    public static bool check = false;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         index = SceneManager.GetActiveScene().buildIndex;

    }


    public void NextLevel()
    {
        PayScoreHP.check = true;
        check = true;
        Score.kills = 0;
        SceneManager.LoadScene(index + 1);
    }
}
