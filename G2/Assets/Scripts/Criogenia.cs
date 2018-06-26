using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class Criogenia{

	public enum Temperature {Hot,Cold};
	public static Temperature room1Temp, room2Temp;
	private static CriogeniaManager manager = GameObject.Find("Criogenia").GetComponent<CriogeniaManager>(); 

	public static void SwapRoomTemp(int index)
	{
		if(index == 1)
		{
			if(room1Temp == Temperature.Cold)
				room1Temp = Temperature.Hot;
			else
				room1Temp = Temperature.Cold;

			manager.SwapTemperature(index,room1Temp);
		}
		else if(index == 2)
		{
			if(room2Temp == Temperature.Cold)
				room2Temp = Temperature.Hot;
			else
				room2Temp = Temperature.Cold;

			manager.SwapTemperature(index,room2Temp);
		}


	}
}
