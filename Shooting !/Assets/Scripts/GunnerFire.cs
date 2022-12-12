using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerFire : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bullets;
    Vector3 PlayerPos;
    float Angle;
    float startTime;
    float realTime;
    float attack = .4f;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        Player = GameObject.Find("Player");
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
                attack += .4f;
                PlayerStats.sound("Enemy Shot");
                Instantiate(bullets, firePoint.position, firePoint.rotation);
            }
        }
    }


}
