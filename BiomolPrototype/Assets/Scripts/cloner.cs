using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloner : MonoBehaviour {
    public GameObject clone;
    private PlayerController pc;

    public void Start()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !pc.isCloned)
        {
            pc.isCloned = true;
            Vector3Int pos = new Vector3Int((int)other.transform.position.x-3, (int)other.transform.position.y, (int)other.transform.position.z);
            Instantiate(clone, pos, other.transform.rotation);
        }
    }
}
