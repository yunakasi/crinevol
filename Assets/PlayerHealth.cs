using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //追加：UIを使うため

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public float invincibleTime = 3f;
    bool isInvincible;
    float invincibleTimer;

    public Slider hpSlider; //追加：HPバーUI

    SpriteRenderer spriteRenderer; //追加：プレイヤーの見た目取得

    void Start()
    {
        currentHealth = maxHealth;

        hpSlider.maxValue = maxHealth; //追加：HPバー最大値
        hpSlider.value = currentHealth; //追加：初期HPを表示

        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); //追加：プレイヤー画像取得
    }

    void Update()
    {
        InvincibleTimer();
    }

    void InvincibleTimer()
    {
    if (!isInvincible)
    {
        spriteRenderer.enabled = true; //追加：無敵終了で表示
        return;
    }

    invincibleTimer -= Time.deltaTime;

    spriteRenderer.enabled = !spriteRenderer.enabled; //追加：点滅

    if (invincibleTimer <= 0)
    {
        isInvincible = false;
        spriteRenderer.enabled = true; //追加：必ず表示
    }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;

        hpSlider.value = currentHealth; //追加：HPバー更新

        Debug.Log("HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

        isInvincible = true;
        invincibleTimer = invincibleTime;
    }

    void Die()
    {
        Debug.Log("Player Dead");

        currentHealth = maxHealth; //追加：HP全回復
        hpSlider.value = currentHealth; //追加：HPバー更新

        CheckpointManager.Instance.RespawnPlayer();
    }

    public int GetCurrentHealth() //追加：HP取得用
    {
        return currentHealth;
    }
}