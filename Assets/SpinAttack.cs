using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAttack : MonoBehaviour
{
    public int damage = 10; //与ダメージ
    public Vector2 attackSize = new Vector2(3f, 1f); //横長の判定


    public float attackDuration = 0.1f; //追加：攻撃判定時間
    public float attackDelay = 0.5f; //後隙

    float cooldown;

    void Update()
    {
        cooldown -= Time.deltaTime;
    }

    public void StartSpin()
    {
        if (cooldown > 0) return;

        cooldown = attackDelay;

        StartCoroutine(SpinCoroutine()); //追加：攻撃処理
    }

    IEnumerator SpinCoroutine() //追加：攻撃時間管理
    {
        Vector2 center = transform.position;

        Collider2D[] hits = Physics2D.OverlapBoxAll(center, attackSize, 0);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }

        yield return new WaitForSeconds(attackDuration); //追加：判定時間
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, attackSize);
    }
}