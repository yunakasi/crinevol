using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpPower = 12f;
    public float fallMultiplier = 2f;
    public float maxFallSpeed = -12f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    bool isGrounded;

    PlayerFloat playerFloat;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFloat = GetComponent<PlayerFloat>();
    }

    void Update()
    {
        CheckGround();
        JumpInput();
        ApplyFall();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

    void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    void ApplyFall()
    {
        // 浮遊中はジャンプの落下処理を止める
        if (playerFloat != null && playerFloat.IsFloating)
            return;

        // 落下加速
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y *
                (fallMultiplier - 1) * Time.deltaTime;
        }

        // 最大落下速度
        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}