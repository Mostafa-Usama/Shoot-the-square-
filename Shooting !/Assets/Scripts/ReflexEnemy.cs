using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexEnemy : MonoBehaviour
{
    Renderer rend;
    public Material thisMat;
    public Material NewMat,matt;
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
    float Starttime = 0;
    float realTime;
    float attack=0;
    public  bool Stance = false;
    public GameObject firepoint;
    Player shake;
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
            Score.score += 60 * Score.combo;
            Score.combo *= 2;
            Score.kills++;
            Destroy(gameObject);
        }
       
        if (realTime > attack)
        {
            attack += 8;

            StartCoroutine(Reflix());
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
            if (Stance)
            {
                Destroy(col.gameObject);
                firepoint.GetComponent<ReflexFire>().Reflixx();

            }
            else
            {
                StartCoroutine(hit());
                PlayerStats.sound("Enemy Hit");
                Destroy(col.gameObject);
                currentHealth -= PlayerTarget.GetComponent<Player>().PlayerDamge;
            }
        }
    }
    void movement()
    {


        if (PlayerTarget != null)
        {
            pos = (PlayerTarget.transform.position - transform.position);
            rb.velocity = new Vector2(pos.x * speed * Time.deltaTime, rb.velocity.y);
        }
        else rb.velocity = Vector2.zero;
    }
    IEnumerator Reflix()
    {
        Stance = true;
        yield return new WaitForSeconds(0.01f);
        this.rend.material = NewMat; 
        yield return new WaitForSeconds(5);
        this.rend.material = thisMat;
        Stance = false;

    }
    IEnumerator hit()
    {
        this.rend.material.color = Color.black;
        yield return new WaitForSeconds(.05f);
        this.rend.material = thisMat;

    }
}