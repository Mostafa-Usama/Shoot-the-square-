using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnEnemy : MonoBehaviour
{
    public int killCounter;
    int kill;
    Scene scene;
    public GameObject[] effect;
    public GameObject [] Enemy;
    float posX;
    float time = 0;
    float Timer=20;
    public float spawnTimer=9;
    GameObject PlayerTarget;
    Vector2 randSpawn;
    int rand;
    Player damg;
    // Start is called before the first frame update
    void Awake ()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeSinceLevelLoad > Timer && spawnTimer!= 4)
        {
            spawnTimer--;
            Timer += 20;
        }

        
            if (NextLevel.arcade)
            {
                if (Time.timeSinceLevelLoad > time && killCounter != kill)
                {

                    time += spawnTimer;
                    rand = Random.Range(0, Enemy.Length);
                    randSpawn = new Vector2(Random.Range(-92, 92), Random.Range(-32, 19));
                    StartCoroutine(Spawner());

                }


            }
            else
        {
            if (Time.timeSinceLevelLoad > time )
            {

                time += spawnTimer;
                rand = Random.Range(0, Enemy.Length);
                randSpawn = new Vector2(Random.Range(-92, 92), Random.Range(-32, 19));
                StartCoroutine(Spawner());

            }

        }


    }
    IEnumerator Spawner() {
        kill++;

        Instantiate(effect[rand], randSpawn, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Instantiate(Enemy[rand], randSpawn, Quaternion.identity);
    }
}

