using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arcade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Score.score = 0;
        NextLevel.arcade = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void arcade()
    {
        
        SceneManager.LoadScene(2);
        NextLevel.arcade = true;

    }
}
