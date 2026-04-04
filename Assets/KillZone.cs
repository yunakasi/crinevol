using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 respawn =
                CheckpointManager.Instance.GetCheckpoint();

            other.transform.position = respawn;
        }
    }
}