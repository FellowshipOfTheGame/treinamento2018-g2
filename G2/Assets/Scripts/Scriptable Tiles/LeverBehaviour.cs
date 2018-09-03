using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : Resp_Interacao {

	public bool isActive = true;
	public int index;
	public bool startingState, currentState;

	void Start()
	{
		index = Criogenia.GetIndex(this.transform.position);
		currentState = startingState;
		if(currentState)
			this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		else
			this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
		Criogenia.leverLayout.Add(this);
	}

	public override void Acao()
	{
		//Criogenia.lastLever = this;
		if(isActive)
			{
				Debug.Log("Click");
				//isActive = false;
				currentState = !currentState;

				if(currentState)
					this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
				else
					this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

				Criogenia.CheckWinCondition();

				if(index == 1)
					Criogenia.SwapRoomTemp(2);
				else if(index == 2)
					Criogenia.SwapRoomTemp(1);
				
				foreach(var player in FindObjectsOfType<Movimento_Player>())
				{
					Debug.Log(player.gameObject.name + "Found");
					if(player.playerIndex != index)
						player.isInControl = true;
				}
			}
	}
	
}
