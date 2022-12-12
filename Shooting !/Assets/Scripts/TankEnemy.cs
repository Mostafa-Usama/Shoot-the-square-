using System.Collections;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    Renderer rend;
    public Material matt;
    public GameObject effect;
    public int maxHealth = 10, currentHealth;
    public HealthBar healthBar;
    public Transform playerPos;
    public Vector3 pos;
    public float speed = 10;
    Player poss, PlayerDamge;
    Rigidbody2D rb;
    GameObject PlayerTarget;
    Player shake;
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindWithTag("Player").GetComponent<Player>();
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        PlayerTarget = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (currentHealth <= 0)
        {
            PlayerStats.sound("E");

            shake.Shake();
            Instantiate(effect, transform.position, Quaternion.identity);
            Score.score += 20 * Score.combo;
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
            rb.velocity = new Vector2(pos.x * Time.deltaTime, rb.velocity.y);
        }
        else rb.velocity = Vector2.zero;
    }
    IEnumerator hit()
    {
        this.rend.material.color = Color.grey;
        yield return new WaitForSeconds(.05f);
        this.rend.material = matt;

    }
}