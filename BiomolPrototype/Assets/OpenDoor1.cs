using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor1 : MonoBehaviour {

    private ActivateMinus am;
    private ActvatePlus ap;
    public GameObject door1, door2;
    public bool isOpen = false;
    
	// Use this for initialization
	void Start () {
        ap = GameObject.FindGameObjectWithTag("Plus").GetComponent<ActvatePlus>();
        am = GameObject.FindGameObjectWithTag("Minus").GetComponent<ActivateMinus>();
        
    }
	
	// Update is called once per frame
	void Update () {
		if(ap.isActive && am.isActive && !isOpen)
        {
            isOpen = true;
            door1.transform.Translate(0, -3, 0);
            door2.transform.Translate(0, 3, 0);
        }
	}
}
