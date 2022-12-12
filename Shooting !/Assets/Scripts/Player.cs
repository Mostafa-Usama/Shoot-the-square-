using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool Shield = false;
    public Animator shake;
    Renderer rend;
    public Material mat, matt,SHIELD;
    int comboBreaker;
    Rigidbody2D rb;
    float move;
    bool isJumping=true;
    bool jump = false;
    public float speed = 12;
    public float jumpHeight = 8;
    int doubleJumb = 0;
    public HealthBar healthBar;
    public int maxHealth = 10;
    public int currentHealth;
    public int enemyDamge = 1;
    public int PlayerDamge = 1;
    int sniperDamge = 5;
    int BossDamge = 3;
    int time = 0;
    public GameObject effect,death;
     
    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<Renderer>();
        DontDestroyOnLoad(this);
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        comboBreaker = currentHealth;
      //  currentHealth = PlayerStats.Instance.PlayerHP;
       // PlayerDamge = PlayerStats.Instance.PlayerDamge;

      
    }

    // Update is called once per frame
    void Update()
    {

        if (comboBreaker >  currentHealth)
        {
            Score.combo = 1;
            comboBreaker = currentHealth;

        }

        if (currentHealth <= 0)
        {
            Instantiate(death, transform.position, Quaternion.identity);
            PlayerStats.sound("E");
            Destroy(gameObject);

        }
       move = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)&& !isJumping && doubleJumb!= 2){
            doubleJumb++;
            jump = true;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (jump)
        {
            PlayerStats.sound("Player Jumb");
            Instantiate(effect, transform.position, Quaternion.identity);
            rb.velocity = Vector2.up * jumpHeight;
            
            if (doubleJumb == 2)
            {
                isJumping = true;
            }
            jump = false;
            
        } 

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DamgeUp")
        {
            PlayerStats.sound("Damge up");
            Destroy(col.gameObject);
            StartCoroutine(damge());
        }
        if (col.gameObject.tag == "Shield")
        {
            PlayerStats.sound("Damge up");
            Destroy(col.gameObject);
            StartCoroutine(shield());
        }

        if (col.gameObject.tag == "Ground")
        {
            isJumping = false;
            doubleJumb = 0;
        }
        if (col.gameObject.tag == "Fire")
        {
            currentHealth = 0;
            healthBar.setHealth(currentHealth);

        }
        if (col.gameObject.tag == "Heal")
        {
            PlayerStats.sound("Heal Up");
            if (currentHealth == maxHealth)
            {
                Destroy(col.gameObject);
            }
            else
            {
                Destroy(col.gameObject);
                if (currentHealth == 29)
                {
                    currentHealth++;
                }
                else
                {
                    currentHealth += 2;
                }
                comboBreaker = currentHealth;
                healthBar.setHealth(currentHealth);
            }
        }
    }
        void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy Bullet")
        {
            StartCoroutine(hit());
            PlayerStats.sound("player Hit");
            Destroy(col.gameObject);
            if (!Shield)
            {
                currentHealth -= enemyDamge;
                healthBar.setHealth(currentHealth);
            }
        }
        if (col.gameObject.tag == "SniperBullet")
        {
            StartCoroutine(hit());
            PlayerStats.sound("player Hit");
            Destroy(col.gameObject);
            if (!Shield)
            {
                currentHealth -= sniperDamge;
                healthBar.setHealth(currentHealth);
            }
        }
        if (col.gameObject.tag == "BossBullet")
        {
            StartCoroutine(hit());
            PlayerStats.sound("player Hit");
            Destroy(col.gameObject);
            if (!Shield)
            {
                currentHealth -= BossDamge;
                healthBar.setHealth(currentHealth);
            }
        }



    }
    IEnumerator damge()
    {
        time = 0;

        time += 15;
        PlayerDamge++;
        yield return new WaitForSeconds(time);
        PlayerDamge--;
    }
    IEnumerator hit()
    {
        if (!Shield)
        {
            this.rend.material = matt;
            yield return new WaitForSeconds(.05f);
            this.rend.material = mat;
        }
    }
    public void Shake()
    {
        shake.SetTrigger("Shake");
    }

    IEnumerator shield()
    {
        Shield = true;
        this.rend.material = SHIELD;
        yield return new WaitForSeconds(8);
        this.rend.material = matt;
        Shield = false;

    }
}
    

