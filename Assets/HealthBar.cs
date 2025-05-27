using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Image fillImage; // ÑªÌõÌî³ä²¿·Ö
    public Health playerHealth;

    private void Start()
    {
        playerHealth = GetComponentInParent<Health>();
        healthBar = GetComponent<Slider>();

        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;

        fillImage = healthBar.fillRect.GetComponent<Image>();
        UpdateColor(playerHealth.curHealth, playerHealth.maxHealth);
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }

    public void UpdateColor(int curHealth, int maxHealth)
    {
        float healthPercentage = (float)curHealth / maxHealth;

        if (healthPercentage > 0.7f)
        {
            fillImage.color = Color.green; // ½¡¿µ×´Ì¬
        }
        else if (healthPercentage > 0.3f)
        {
            fillImage.color = Color.yellow; // ¾¯¸æ×´Ì¬
        }
        else
        {
            fillImage.color = Color.red; // Î£ÏÕ×´Ì¬
        }
    }
}
