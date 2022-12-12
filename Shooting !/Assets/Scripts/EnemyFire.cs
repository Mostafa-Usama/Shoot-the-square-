using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public Transform firePoint;
    
    public GameObject bullets;
    Vector3 PlayerPos;
    float Angle;
    float startTime;
    float realTime;
    public GameObject Player;
    float attack=.8f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        realTime = Time.time - startTime;
        if (Player != null)
        {
            PlayerPos = Player.transform.position - transform.position;
            Angle = Mathf.Atan2(PlayerPos.y, PlayerPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, Angle - 90);

            if (realTime > attack)
            {
                attack += 0.8f;
                PlayerStats.sound("Enemy Shot");
                Instantiate(bullets, firePoint.position, firePoint.rotation);
                
            }
        }
    }

    
}