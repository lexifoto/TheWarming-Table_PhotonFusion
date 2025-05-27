using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Image fillImage; // Ѫ����䲿��
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
            fillImage.color = Color.green; // ����״̬
        }
        else if (healthPercentage > 0.3f)
        {
            fillImage.color = Color.yellow; // ����״̬
        }
        else
        {
            fillImage.color = Color.red; // Σ��״̬
        }
    }
}
