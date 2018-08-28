using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMinus : MonoBehaviour {

    public bool isActive = false;

    public GameObject clone;

    private void Start()
    {
        
    }
    private void Update()
    {

        if (clone == null)
        {
            clone = GameObject.FindGameObjectWithTag("Clone");
            if (isActive)
            {
                isActive = false;
            }
        }
    }
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
