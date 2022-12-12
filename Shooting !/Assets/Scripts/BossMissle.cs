using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissle : MonoBehaviour
{
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Fire")
        {
            PlayerStats.sound("Missle LAnd");
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
