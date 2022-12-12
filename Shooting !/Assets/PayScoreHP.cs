using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayScoreHP : MonoBehaviour
{
    GameObject player;
    public static bool check = true;
    public static bool full = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PayScore()
    {

        if (Score.score >= 1000)
        {
             if (player.GetComponent<Player>().currentHealth == 30)
            {
                full = true;
            }
             else if (player.GetComponent<Player>().currentHealth == 29)
            {
                player.GetComponent<Player>().currentHealth += 1;
            }
             else
            {
                player.GetComponent<Player>().currentHealth += 2;

            }
            int health = player.GetComponent<Player>().currentHealth;
            player.GetComponent<Player>().healthBar.setHealth(health);
            if (!full)
            {
                Score.score -= 1000;
            }

        }
        else
        {
            check = false;
        }

    }
}
