using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Gradient color;
    public Image fill;
    
    void Awake()
    {

        

    }
    public void setMaxHealth (int Health)
    {
        healthBar.maxValue = Health;
        healthBar.value = Health;
        fill.color = color.Evaluate(1f);
    }
    public void setHealth (int health)
    {

        healthBar.value = health;
        fill.color = color.Evaluate(healthBar.normalizedValue);
    }

}
