using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullets;
    Vector3 PlayerPos;
    float Angle;
    float time;
     GameObject Player;
  

    // Start is called before the first frame update
    void Start()
    {
    
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            PlayerPos = Player.transform.position - transform.position;
            Angle = Mathf.Atan2(PlayerPos.y, PlayerPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, Angle - 90);
            
       
        }
    }
  public void Reflixx()
    {
            PlayerStats.sound("Enemy Shot");
            Instantiate(bullets, firePoint.position, firePoint.rotation);
    }

}