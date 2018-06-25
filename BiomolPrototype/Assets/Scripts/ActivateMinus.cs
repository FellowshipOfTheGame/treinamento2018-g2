using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMinus : MonoBehaviour {

    public bool isActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Clone"))
        {
            isActive = true;
           
        }
    }
}
