using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    public GameObject[] Ground;
  
    // Start is called before the first frame update
    void Start()
    {
        int randGround = Random.Range(0, Ground.Length);
 
        Instantiate(Ground[randGround], transform.position, Quaternion.identity);

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
