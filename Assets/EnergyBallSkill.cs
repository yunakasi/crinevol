using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallSkill : MonoBehaviour
{
    public GameObject energyBallPrefab; //弾Prefab
    public Transform firePoint; //発射位置

    public float inputWindow = 0.5f; //受付時間
    public float cooldown = 0.5f; //後隙

    public float endLag = 0.5f; //発射後の硬直時間
    public float slowMultiplier = 0.3f; //移動速度低下倍率

    PlayerMove playerMove; //PlayerMove取得

    float inputTimer;
    float cooldownTimer;

    bool waitingCommand;

    void Start() 
    {
         playerMove = GetComponent<PlayerMove>(); 
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.S)) //コマンド開始
        {
            waitingCommand = true;
            inputTimer = inputWindow;
        }

        if (waitingCommand)
        {
            inputTimer -= Time.deltaTime;

            if (inputTimer <= 0)
            {
                waitingCommand = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    Fire(Vector2.left);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Fire(Vector2.right);
                }
            }
        }
    }

    void Fire(Vector2 direction)
    {
        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;
        waitingCommand = false;

        playerMove.SetSpeedMultiplier(slowMultiplier);//移動速度を遅くする

        GameObject ball = Instantiate(energyBallPrefab, firePoint.position, Quaternion.identity);

        ball.GetComponent<EnergyBall>().Shoot(direction);

        StartCoroutine(AttackCooldown()); //硬直開始
    }

    //発射後の硬直処理
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(endLag); //硬直時間
        
        //移動速度を元に戻す
        playerMove.SetSpeedMultiplier(1f);
    }
}