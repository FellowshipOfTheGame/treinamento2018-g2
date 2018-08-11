using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : Resp_Interacao {

	public bool isActive = true;
	public int index;

	void Start()
	{
		if(transform.position.x < GameObject.Find("Criogenia").transform.position.x)
			index = 1;
		else
			index = 2;
	}

	public override void Acao()
	{
		//Criogenia.lastLever = this;
		if(isActive)
			{
				Debug.Log("CLick");
				//isActive = false;
				if(index == 1)
					Criogenia.SwapRoomTemp(2);
				else if(index == 2)
					Criogenia.SwapRoomTemp(1);
			}
	}
	
}
