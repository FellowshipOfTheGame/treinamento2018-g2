using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActvatePlus : MonoBehaviour {

    private ActivateMinus am;
    public bool isActive = false;
    
    void Start()
    {
        am = GameObject.FindGameObjectWithTag("Minus").GetComponent<ActivateMinus>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Clone"))
        {
            isActive = true;
            if (am.isActive && isActive)
            {

            }
        }
    }
}
