using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloner : MonoBehaviour {
    public GameObject clone, spawnPoint;
    public PlayerController pc;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !pc.isCloned)
        {
            pc.isCloned = true;
            Instantiate(clone, spawnPoint.transform.position, other.transform.rotation);
        }
    }
}
