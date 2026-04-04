using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMove move;

    void Start()
    {
        move = GetComponent<PlayerMove>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float abilityInput = Input.GetAxisRaw("AbilityHorizontal");

        move.Move(horizontal);
    }
}