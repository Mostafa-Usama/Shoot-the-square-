using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraNotDestroy : MonoBehaviour
{
    AudioSource aaudio;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        aaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            aaudio.enabled = false;
        }
    }
}
