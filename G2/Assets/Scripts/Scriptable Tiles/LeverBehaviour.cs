using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : MonoBehaviour {

	private bool isActive = true;
	public int index;

	void Start()
	{
		Debug.Log(GameObject.Find("Criogenia").transform.position.x);
		Debug.Log(transform.position.x);
		if(transform.position.x < GameObject.Find("Criogenia").transform.position.x)
			index = 1;
		else
			index = 2;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			if(Input.GetKeyDown(KeyCode.E) && isActive && other.gameObject.GetComponent<PlayerController>().isInControl)
			{
				Debug.Log("CLick");
				isActive = false;
				if(index == 1)
					Criogenia.SwapRoomTemp(2);
				else if(index == 2)
					Criogenia.SwapRoomTemp(1);
			}
		}
	}
	
}
