using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	bool isActive = true;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && isActive)
		{
			other.transform.position = this.transform.GetChild(0).transform.position;
			isActive = false;
			GetComponent<SpriteRenderer>().color = new Color(1f,0,0,1);
		}
	}
}
