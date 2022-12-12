using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public  int damge = 1;
    public float speed = 30;
    Rigidbody2D rb;
    Vector2 MousePos;
    public GameObject playerEffect,EnemyBulletEffect,bossEffect,sniperEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
      
    {
        

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D col)
    {

        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Fire")
        {
            if (gameObject.tag == "Bullet")
            {
               
                Instantiate(playerEffect, transform.position, Quaternion.identity);
            }
            if (gameObject.tag == "Enemy Bullet")
            {
               
                Instantiate(EnemyBulletEffect, transform.position, Quaternion.identity);
            }
            if (gameObject.tag == "BossBullet")
            {
                
                Instantiate(bossEffect, transform.position, Quaternion.identity);
            }

            if (gameObject.tag == "SniperBullet")
            {

                Instantiate(sniperEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Enemy" && gameObject.tag == "Bullet")
        {
            Instantiate(playerEffect, transform.position, Quaternion.identity);
        }
        if (col.gameObject.tag == "Player" && gameObject.tag == "Enemy Bullet")
        {
            Instantiate(EnemyBulletEffect, transform.position, Quaternion.identity);
        }
        if (col.gameObject.tag == "Player" && gameObject.tag == "BossBullet")
        {
            Instantiate(bossEffect, transform.position, Quaternion.identity);
        }
        if (col.gameObject.tag == "Player" && gameObject.tag == "SniperBullet")
        {
            Instantiate(sniperEffect, transform.position, Quaternion.identity);
        }

    }
}
