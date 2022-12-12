using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour
{
    Renderer rend;
    public Material matt;
    public int maxHealth = 15, currentHealth;
    public HealthBar healthBar;
    public Transform playerPos;
    public Vector3 pos;
    public float speed = 10;
    public GameObject deathEffect,bulletEffect;
    Player PlayerDamge;
    Rigidbody2D rb;
    GameObject PlayerTarget;
    public float time = 4;
    Player shake;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        shake = GameObject.FindWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        PlayerTarget = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

       

        if (currentHealth <= 0)
        {
            PlayerStats.sound("E");
            
            shake.Shake();
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Score.score += 50*Score.combo;
            Score.combo *= 2;
            Score.kills++;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fire")
        {
            PlayerStats.sound("E");
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            StartCoroutine(hit());
            PlayerStats.sound("Enemy Hit");
            Destroy(col.gameObject);
            currentHealth -= PlayerTarget.GetComponent<Player>().PlayerDamge;
        }

    }
    IEnumerator hit()
    {
        this.rend.material.color = Color.black;
        yield return new WaitForSeconds(.05f);
        this.rend.material = matt;

    }
}

