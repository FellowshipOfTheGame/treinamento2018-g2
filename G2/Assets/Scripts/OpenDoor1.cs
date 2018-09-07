using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor1 : MonoBehaviour {

    public ActivateMinus am;
    public ActvatePlus ap;
    public GameObject door1, door2, clone;
    [SerializeField] Camera BiomolCam;
    public bool isOpen = false;
    

	
	// Update is called once per frame
	void Update () {
		if(ap.isActive && am.isActive && !isOpen)
        {
            isOpen = true;
            //door1.transform.Translate(0, -3, 0);
            //door2.transform.Translate(0, 3, 0);
            Destroy(door1);
            Destroy(door2);
            clone = GameObject.FindGameObjectWithTag("Clone");
            Destroy(clone);
            CameraManager.isBiomolDone = true;
            GameManager.instance.CompletedPuzzles++;
            GameManager.instance.BioIcon.SetActive(true);
        }
	}
}
