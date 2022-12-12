using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    Renderer rend;
    public  Material mat;
    public GameObject effect;
    public int maxHealth = 10, currentHealth;
    public HealthBar healthBar;
    public Transform playerPos;
    public Vector3 pos;
    public float speed = 10;
    Player PlayerDamge;
    Rigidbody2D rb;
    GameObject PlayerTarget;
    public float Starttime;
    float realTime;
    Player shake;
    float time = 3;
    // Start is called before the first frame update
    void Start()
    {
        Starttime = Time.time;
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        PlayerTarget = GameObject.Find("Player");
        shake = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        realTime = Time.time - Starttime;

        movement();

        if (currentHealth <= 0)
        {
            shake.Shake();
            PlayerStats.sound("E");

            Instantiate(effect, transform.position, Quaternion.identity);
            Score.score += 20*Score.combo;
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
            Instantiate(effect, transform.position, Quaternion.identity);
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            StartCoroutine(hit());
            PlayerStats.sound("Enemy Hit");
            Destroy(col.gameObject);
            currentHealth -= PlayerTarget.GetComponent<Player>().PlayerDamge;      }

    }
    void movement()
    {
        if (realTime >= time)
        {
            time += 3;
            rb.velocity = Vector2.up * 25;
        }

        if (PlayerTarget != null)
        {
            pos.x = (PlayerTarget.transform.position.x - transform.position.x);
            rb.velocity = new Vector2(pos.x * speed * Time.deltaTime, rb.velocity.y);
        }
        else rb.velocity = Vector2.zero;
    }
    IEnumerator hit()
    {
        this.rend.material.color = Color.gray;
        yield return new WaitForSeconds(.05f);
        this.rend.material = mat;

    }
}

