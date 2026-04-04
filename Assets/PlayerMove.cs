using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float groundMoveSpeed = 5f;
    public float floatRiseSpeed = 6f;
    public float floatFallSpeed = 5f;

    Rigidbody2D rb;
    PlayerFloat playerFloat;
    FloatMotion floatMotion;

    PlayerState playerState; //プレイヤー状態管理

    float inputLockTimer = 0f;

    float speedMultiplier = 1f; //移動速度倍率

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFloat = GetComponent<PlayerFloat>();
        floatMotion = GetComponentInChildren<FloatMotion>();

        playerState = GetComponent<PlayerState>(); 
    }

    void Update()
    {
        // 復活直後の入力ロック
        if (inputLockTimer > 0)
        {
            inputLockTimer -= Time.deltaTime;
            return;
        }
        float input = Input.GetAxisRaw("Horizontal");
        Move(input);
    }

    public void Move(float input)
    {
        float moveSpeed = groundMoveSpeed;

        // 浮遊中の移動速度変更
        if (playerFloat != null && playerFloat.IsFloating)
        {
            if (playerFloat.VerticalVelocity > 0)
            {
                moveSpeed = floatRiseSpeed;
            }
            else
            {
                moveSpeed = floatFallSpeed;
            }
        }

        rb.velocity = new Vector2(input * moveSpeed * speedMultiplier, rb.velocity.y);

        // 向き変更
        if (input > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (input < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // フワフワ制御
        if (floatMotion != null)
        {
            if (Mathf.Abs(input) > 0.1f)
            {
                floatMotion.isFloating = false;
            }
            else
            {
                floatMotion.isFloating = true;
            }
        }
    }
    //追加：外部から速度を変更する関数
public void SetSpeedMultiplier(float value)
{
    speedMultiplier = value;
}
}

