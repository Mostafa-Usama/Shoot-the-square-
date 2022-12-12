using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
   public static  bool mute = false;
    public  Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = AudioListener.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Volume()
    {
        AudioListener.volume =   (slider.value);
    }
}
