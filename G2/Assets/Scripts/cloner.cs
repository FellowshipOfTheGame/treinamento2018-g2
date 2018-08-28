using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloner : MonoBehaviour {
    public GameObject clone;
    private PlayerController pc;

    public void Start()
    {
        pc = GameObject.Find("Player1").GetComponent<PlayerController>();
    }

    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !pc.isCloned)
        {
            pc.isCloned = true;
            Vector2 pos = new Vector2((int)other.transform.position.x-3, other.transform.position.y - 0.5f);
            Instantiate(clone, pos, other.transform.rotation);
        }
    }
}
