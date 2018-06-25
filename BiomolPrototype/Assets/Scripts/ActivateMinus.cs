using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMinus : MonoBehaviour {
    private ActvatePlus ap;
    public bool isActive = false;
    private void Start()
    {
        ap = GameObject.FindGameObjectWithTag("Plus").GetComponent<ActvatePlus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Clone"))
        {
            isActive = true;
            if(ap.isActive && isActive)
            {

            }
        }
    }
}
