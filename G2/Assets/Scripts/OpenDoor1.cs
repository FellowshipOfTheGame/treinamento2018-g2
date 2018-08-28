using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor1 : MonoBehaviour {

    public ActivateMinus am;
    public ActvatePlus ap;
    public GameObject door1, door2, clone;
    public bool isOpen = false;
    

	
	// Update is called once per frame
	void Update () {
		if(ap.isActive && am.isActive && !isOpen)
        {
            isOpen = true;
            door1.transform.Translate(0, -3, 0);
            door2.transform.Translate(0, 3, 0);
            clone = GameObject.FindGameObjectWithTag("Clone");
            Destroy(clone);
        }
	}
}
