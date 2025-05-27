using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public KeyCode damageKey; // �󶨵Ŀ�Ѫ����

    void Start()
    {
        curHealth = maxHealth;
        healthBar.SetHealth(curHealth);
    }

    void Update()
    {
        // ��Ѫ������ damageKey���� A, S, D, W��
        if (Input.GetKeyDown(damageKey))
        {
            DamagePlayer(10);
        }

        // ��Ѫ����ס LeftShift + damageKey����Ҫһֱ��ס��
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(damageKey))
        {
            IncreaseHealth(1); // ���Ƽ�Ѫ����
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth); // ����Ѫ�������� 0
        healthBar.SetHealth(curHealth);
        healthBar.UpdateColor(curHealth, maxHealth); // ����Ѫ����ɫ
    }

    public void IncreaseHealth(int amount)
    {
        curHealth = Mathf.Min(curHealth + amount, maxHealth); // ȷ�����������ֵ
        healthBar.SetHealth(curHealth);
        healthBar.UpdateColor(curHealth, maxHealth);
    }
}
