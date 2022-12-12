using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public int one, two, three;
    public static bool check = false;
    public GameObject pause;
    public GameObject nextLevel;
  public   bool pool = false;
   public  int index;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        index = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!check)
            {
                check = true;
                Time.timeScale = 0f;
                pause.SetActive(true);
            }
            else
            {
                check = false;
                Time.timeScale = 1f;
                pause.SetActive(false);
            }


         
        }
     
        if (index == 2 && NextLevel.arcade)
        {
            if (Score.kills == one)
            {

                nextLevel.SetActive(true);
                Time.timeScale = 0f;
                player.transform.position = new Vector3(-79.3f, -25.5f, 0);
                PayScoreHP.full = false;
            }
        }
        if (index == 3)
        {
            if (Score.kills == two)
            {
                nextLevel.SetActive(true);
                Time.timeScale = 0f;
                player.transform.position = new Vector3(-79.3f, -25.5f, 0);
                PayScoreHP.full = false;

            }
        }
         if (index == 4)
        {
            if (Score.kills == three)
            {
                nextLevel.SetActive(true);
                Time.timeScale = 0f;
                player.transform.position = new Vector3(-79.3f, -25.5f, 0);
                PayScoreHP.full = false;


            }
     
        }
        if (NewLevel.check)
        {
            Time.timeScale = 1f;

            nextLevel.SetActive(false);
            NewLevel.check = false;
        }
        
    }
   
}
