using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    public static bool stance = false, check = false;
    public Transform firePoint;
    public GameObject enemy,SpawnEffect;
    public GameObject bullets;
    Vector3 PlayerPos;
    float Angle;
    float timeNormalAttack=0;
    float timeSkyAttack=2;
    float timeBetSky=12;
    float timeBetNormal=8;
    float timeShotGun=10;
    float timeBetShotGun=20;
    public GameObject Player,missle,ShotGunBullet;
    GameObject boss;
    Vector2 randPlace;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("BOSS");
       
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

           
            
                if (Time.timeSinceLevelLoad >= timeNormalAttack)
                {
                    timeNormalAttack += timeBetNormal;
                    StartCoroutine(fire());

                }

                if (Time.timeSinceLevelLoad >= timeSkyAttack)
                {
                    timeSkyAttack += timeBetSky;
                    StartCoroutine(AirAttack());
                }
                if (Time.timeSinceLevelLoad >= timeShotGun)
                {
                    timeShotGun += timeBetShotGun;
                    StartCoroutine(ShotGun());
                }
        }
    }
    IEnumerator fire()
    {

        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(.5f);
            Instantiate(bullets, firePoint.position, firePoint.rotation);
            PlayerStats.sound("Boss Bullet");
        }

    }
    IEnumerator ShotGun()
     {

        stance = true;
        check = true;
        Instantiate(SpawnEffect, new Vector3(20.6f, -19.2f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(SpawnEffect, new Vector3(13.5f, -20.4f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(SpawnEffect, new Vector3(6.4f, -12.6f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(SpawnEffect, new Vector3(2.5f, -25.5f, 0), Quaternion.identity);

        yield return new WaitForSeconds(1f);


        Instantiate(enemy, new Vector3(20.6f, -19.2f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy, new Vector3(13.5f, -20.4f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy, new Vector3(6.4f, -12.6f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(enemy, new Vector3(2.5f, -25.5f, 0), Quaternion.identity);
        


    }

    IEnumerator AirAttack()
    {

        for (int i = 0; i < 15; i++)
        {
            Vector2 randPlace = new Vector2(Random.Range(-92f, 30f), 21f);
            yield return new WaitForSeconds(0.5f);
            Instantiate(missle, randPlace, Quaternion.identity);
        }

    }
}
