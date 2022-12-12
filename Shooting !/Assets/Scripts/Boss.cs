using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Renderer rend;
    public Material mat;
    public Material matt;
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
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        GunnerEnemy.stance = 0;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        
        PlayerTarget = GameObject.Find("Player");
        PlayerTarget.transform.position = new Vector3(-79.3f, -25.5f, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (BossFire.stance)
        {
            StartCoroutine(Stance());
            BossFire.stance = false;
        }
        if (currentHealth <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            PlayerStats.sound("Boss Death");
            Score.score += 1000;
            Destroy(gameObject);
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
            healthBar.setHealth(currentHealth);
        }

    }
   IEnumerator Stance()
    {
        this.rend.material = mat;
       while (GunnerEnemy.stance != 4)
        {
            if (currentHealth< maxHealth)
            {
                currentHealth += 2;
                healthBar.setHealth(currentHealth);
            }
            yield return new WaitForSeconds(1.5f);
        }
        this.rend.material = matt;
        
            BossFire.check = false;
            GunnerEnemy.stance = 0;
        
    }
    IEnumerator hit()
    {
        this.rend.material.color = Color.grey;
        yield return new WaitForSeconds(.05f);
        if (BossFire.check)
            this.rend.material = mat;
        else this.rend.material = matt;

    }
}
