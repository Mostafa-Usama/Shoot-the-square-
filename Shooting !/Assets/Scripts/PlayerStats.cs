using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    GameObject player;
    GameObject boss;
    public GameObject canvas,Camera;
    public static AudioClip attack, playerJumb, playerHit, healUp, damgeUp, bossBullet, bossDeath, bossMissle, enemyShot, EnemyHit, EnemyDeath;
    static new AudioSource audio;
    public static PlayerStats Instance;
    public int PlayerHP;
    public int PlayerDamge;
    // Start is called before the first frame update
    void Awake()
    {
        attack = Resources.Load<AudioClip>("attack");
        playerJumb = Resources.Load<AudioClip>("Player Jumb");
        playerHit = Resources.Load<AudioClip>("player Hit");
        healUp = Resources.Load<AudioClip>("Heal Up");
        damgeUp = Resources.Load<AudioClip>("Damge up");
        bossBullet = Resources.Load<AudioClip>("Boss Bullet");
        bossDeath = Resources.Load<AudioClip>("Boss Death");
        bossMissle = Resources.Load<AudioClip>("Missle LAnd");
        EnemyDeath = Resources.Load<AudioClip>("E");
        enemyShot = Resources.Load<AudioClip>("Enemy Shot");
        EnemyHit = Resources.Load<AudioClip>("Enemy Hit");
        audio = GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        DontDestroyOnLoad(this);
          /* 
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        else if (Instance!= this)
        {
            Destroy(gameObject);
        
        }
          */

    }
       
    // Update is called once per frame
    void Update()
    {

        boss = GameObject.Find("BOSS");
        if(player.GetComponent<Player>().currentHealth <=0 )
        {
            StartCoroutine(Restart());
        }
        if (boss.GetComponent<Boss>().currentHealth <= 0)
        {
            StartCoroutine(Win());
        }
    }
  
    public static void sound(string sound)
    {

        switch (sound)
        {
            case "attack":
                audio.PlayOneShot(attack);
                break;
            case "Player Jumb":
                audio.PlayOneShot(playerJumb);
                break;
            case "player Hit":
                audio.PlayOneShot(playerHit);
                break;
            case "Heal Up":
                audio.PlayOneShot(healUp);
                break;
            case "Damge up":
                audio.PlayOneShot(damgeUp);
                break;
            case "Boss Bullet":
                audio.PlayOneShot(bossBullet);
                break;
            case "Boss Death":
                audio.PlayOneShot(bossDeath);
                break;
            case "Missle LAnd":
                audio.PlayOneShot(bossMissle);
                break;
            case "E":
                audio.PlayOneShot(EnemyDeath);
                break;
            case "Enemy Shot":
                audio.PlayOneShot(enemyShot);
                break;
            case "Enemy Hit":
                audio.PlayOneShot(EnemyHit);
                break;
        }

    }
    
    IEnumerator Restart()
    {
        Time.timeScale = .4f;
        yield return new WaitForSeconds(1.5f);
        Destroy(canvas);
        Destroy(Camera);
        SceneManager.LoadScene(6);
    }
    IEnumerator Win()
    {
        Time.timeScale = .4f;
        yield return new WaitForSeconds(3);
        Destroy(canvas);
        Destroy(player);
        Destroy(Camera);
        SceneManager.LoadScene(8);

    }


}
