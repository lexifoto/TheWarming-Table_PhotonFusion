using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public KeyCode damageKey; // 绑定的扣血按键

    void Start()
    {
        curHealth = maxHealth;
        healthBar.SetHealth(curHealth);
    }

    void Update()
    {
        // 扣血：按下 damageKey（如 A, S, D, W）
        if (Input.GetKeyDown(damageKey))
        {
            DamagePlayer(10);
        }

        // 加血：按住 LeftShift + damageKey（需要一直按住）
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(damageKey))
        {
            IncreaseHealth(1); // 控制加血速率
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth); // 限制血量不低于 0
        healthBar.SetHealth(curHealth);
        healthBar.UpdateColor(curHealth, maxHealth); // 更新血条颜色
    }

    public void IncreaseHealth(int amount)
    {
        curHealth = Mathf.Min(curHealth + amount, maxHealth); // 确保不超过最大值
        healthBar.SetHealth(curHealth);
        healthBar.UpdateColor(curHealth, maxHealth);
    }
}
