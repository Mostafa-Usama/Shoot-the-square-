using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDisappear : MonoBehaviour
{
    float start;
    float real;
    // Start is called before the first frame update
    void Start()
    {
        start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        real = Time.time - start;
        if (real > 9)
        {
            Destroy(gameObject);
        }
        
    }
}
