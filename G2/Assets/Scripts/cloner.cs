using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloner : MonoBehaviour {
    public GameObject clone, spawnPoint, currentClone;
    public PlayerController pc;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !pc.isCloned)
        {
            pc.isCloned = true;
            currentClone = Instantiate(clone, spawnPoint.transform.position, other.transform.rotation);
            Movimento_Player cloneMvm = currentClone.GetComponent<Movimento_Player>();
            char playerIndex = pc.gameObject.name[pc.gameObject.name.Length - 1];
            cloneMvm.Horizontal = $"Horizontal_P{playerIndex}";
            cloneMvm.Vertical = $"Vertical_P{playerIndex}";
            cloneMvm.Correr = $"Correr_P{playerIndex}";
        }
    }
}
