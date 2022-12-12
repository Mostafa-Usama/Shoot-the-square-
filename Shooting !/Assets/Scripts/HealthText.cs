using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthText : MonoBehaviour
{
    public Text text;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().currentHealth < 0)
        {
            text.text = "HP: 0";
        }
        else

        {
            text.text = "HP: " + player.GetComponent<Player>().currentHealth;
        }
    }
}
