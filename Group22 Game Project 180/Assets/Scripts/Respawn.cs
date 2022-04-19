using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawner"))
        {
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
        
    }


}
