using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    SpinAttack spinAttack; //追加：スピン技

    void Start()
    {
        spinAttack = GetComponent<SpinAttack>(); //追加
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //左クリック
        {
            spinAttack.StartSpin(); //追加：スピン発動
        }
    }
}