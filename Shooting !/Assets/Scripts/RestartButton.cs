using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartButton : MonoBehaviour
{
    public GameObject player, canvas,Camera;
    // Start is called before the first frame update
  

    public void Restart()
    {
        Score.kills = 0;
        Score.combo = 1;
        SceneManager.LoadScene(0);
        Destroy(player);
        Destroy(canvas);
        Destroy(Camera);
        Time.timeScale = 1f;
    }
}
