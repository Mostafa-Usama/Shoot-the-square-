using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerEnemy : MonoBehaviour
{
    Renderer rend;
    public Material mat;
    public static int stance = 0;
    public GameObject effect;
    public int maxHealth = 10, currentHealth;
    public HealthBar healthBar;
    public Transform playerPos;
    public Vector3 pos;
    public float speed = 10;
    Player poss;
    Rigidbody2D rb;
    GameObject PlayerTarget;
    GameObject PlayerDamge;
    public int dmg;
    Player shake;
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.Find("Player").GetComponent<Player>();
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        PlayerTarget = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera (1)");

    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (currentHealth <= 0)

        {
            stance++;
            PlayerStats.sound("E");
            if (cam != null)
            {
                shake.Shake();
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Score.score += 25 * Score.combo;
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
            currentHealth -= PlayerTarget.GetComponent<Player>().PlayerDamge;
        }

    }
    void movement()
    {


        if (PlayerTarget != null)
        {
            pos = (PlayerTarget.transform.position - transform.position);
            rb.velocity = new Vector2(pos.x * speed * Time.deltaTime, rb.velocity.y );
        }
        else rb.velocity = Vector2.zero;
    }
    IEnumerator hit()
    {
        this.rend.material.color = Color.grey;
        yield return new WaitForSeconds(.05f);
        this.rend.material = mat;

    }
}