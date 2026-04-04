using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloat : MonoBehaviour
{
    public float floatForce = 8f;
    public float floatTimeMax = 6f;
    public float maxFallSpeed = -4f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D rb;

    bool isGrounded;
    bool isFloating;
    bool floatUsed;

    float floatTimer;

    public bool IsFloating => isFloating;
    public float VerticalVelocity => rb.velocity.y;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        floatTimer = floatTimeMax;
    }

    void Update()
    {
        GroundCheck();
        FloatInput();
        FloatMove();
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (isGrounded)
        {
            isFloating = false;
            floatTimer = floatTimeMax;
            floatUsed = false;
        }
    }

    void FloatInput()
    {
        // 浮遊開始
        if (!isGrounded && !floatUsed && Input.GetKeyDown(KeyCode.Space))
        {
            isFloating = true;
            floatUsed = true;
        }

        // 急降下
        if (isFloating && Input.GetKeyDown(KeyCode.S))
        {
            isFloating = false;
        }
    }

    void FloatMove()
    {
        if (!isFloating) return;

        // 上昇時間
        if (floatTimer > 0)
        {
            floatTimer -= Time.deltaTime;
        }

        // 上昇
        if (Input.GetKey(KeyCode.Space) && floatTimer > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, floatForce);
        }

        // 浮遊落下速度
        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}