using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActvatePlus : MonoBehaviour {

    public bool isActive = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Clone"))
        {
            isActive = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Clone"))
        {
            isActive = false;

        }
    }
}
