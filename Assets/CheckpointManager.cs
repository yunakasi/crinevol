using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    Vector3 checkpointPosition;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // 最初のチェックポイント
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        checkpointPosition = player.transform.position;
    }

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPosition = pos;
    }

    public Vector3 GetCheckpoint()
    {
        return checkpointPosition;
    }

    public void RespawnPlayer()
{
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    player.transform.position = checkpointPosition;

    Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
    rb.velocity = Vector2.zero;

    Vector3 scale = player.transform.localScale;
    scale.x = Mathf.Abs(scale.x);
    player.transform.localScale = scale;
}
}