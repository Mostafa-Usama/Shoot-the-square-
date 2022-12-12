using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class camera : MonoBehaviour
{
    GameObject boss;
    
    
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("BOSS");
        
    }
    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<Boss>().currentHealth <= 0)
        {
            StartCoroutine(Restart());  
        }
        
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(8);
    }
}
