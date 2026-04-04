using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 5; //追加：プレイヤーに与えるダメージ

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy Hit"); //追加：触れたか確認
        
        if (collision.CompareTag("Player")) //追加：プレイヤーに当たったら
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>(); //追加：PlayerHealth取得

            if (health != null)
            {
                health.TakeDamage(damage); //追加：ダメージを与える
            }
        }
    }
}