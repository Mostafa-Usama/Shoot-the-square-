using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextLevel;
   void Start()
    {
        Score.score = 0;

    }
    public void Play()
    {
        Destroy(nextLevel);
        SceneManager.LoadScene(2);
    }
    

    } 
