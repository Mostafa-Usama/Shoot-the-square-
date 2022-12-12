using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawn : MonoBehaviour
{
    public GameObject[] Items;
    float time = 10;
    float spawnTimer = 10;
    int randItem;
    Vector2 randSpawn;
    int start = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > time)
        {
            if (Score.kills == 20)
            {
                start = 2;
            }
            
            randItem = Random.Range(0, Items.Length-start);
            time += spawnTimer;
            randSpawn = new Vector2(Random.Range(-93, 93), 21);
            Instantiate(Items[randItem], randSpawn, Quaternion.identity);
        }
    }
}
