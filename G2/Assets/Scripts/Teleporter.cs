using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	bool isActive = true;
	[SerializeField] private GameObject Cloner;
	public GameObject[] FireWalls;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" && isActive)
		{
			Cloner.GetComponent<cloner>().pc = other.GetComponent<PlayerController>();
			
			foreach(var wall in FireWalls)
			{
				wall.GetComponent<FireCollider>().player1 = other.gameObject;
			}

			other.transform.position = this.transform.GetChild(0).transform.position;
			isActive = false;
			GetComponent<SpriteRenderer>().color = new Color(1f,0,0,1);
		}
	}
}
