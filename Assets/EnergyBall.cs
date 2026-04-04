using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public float speed = 10f; //弾の速度
    public float lifeTime = 1.5f; //消える時間
    public int damage = 10; //ダメージ

    Rigidbody2D rb;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>(); //追加：Rigidbody取得
    }

    void Start()
    {
        Destroy(gameObject, lifeTime); //追加：時間で消える
    }

    public void Shoot(Vector2 direction) //追加：発射
    {
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}