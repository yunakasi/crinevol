using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20; //追加：敵の最大HP
    int currentHealth; //追加：現在HP

    void Start()
    {
        currentHealth = maxHealth; //追加：ゲーム開始時にHPを設定
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //追加：ダメージを受ける

        Debug.Log("Enemy HP: " + currentHealth); //追加：確認用ログ

        if (currentHealth <= 0) //追加：HPが0以下なら
        {
            Die(); //追加：死亡処理
        }
    }

    void Die()
    {
        Debug.Log("Enemy Dead"); //追加：確認用ログ

        Destroy(gameObject); //追加：敵を消す
    }
}