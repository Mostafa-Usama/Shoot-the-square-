using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static bool arcade = false;
    GameObject player;
    Vector3 StartPostion;
    public int nextLevel = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        StartPostion = player.transform.position;
       /* if (Score.kills >= nextLevel)
        {
            
            SceneManager.LoadScene(3);
            player.transform.position = new Vector3(-79.3f,-25.5f,0);
            Destroy(this.gameObject);
        }*/
    }
}
