using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	private int nOfPlayers = 0;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			nOfPlayers++;
			if(nOfPlayers >= 2)
			{
				nOfPlayers = 0;
				GameManager.instance.NextLevel();
			}

		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(nOfPlayers > 0)
				nOfPlayers--;
		}
	}
}
