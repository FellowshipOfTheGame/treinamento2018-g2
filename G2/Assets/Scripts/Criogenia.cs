using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class Criogenia{

	public enum Temperature {Hot,Cold};
	public static Temperature room1Temp, room2Temp;
	public enum TileType {Ice, Water, Dry};
	private static CriogeniaManager manager = GameObject.Find("Criogenia").GetComponent<CriogeniaManager>();
	public static List<Vector2> lastSafePosP1 = new List<Vector2>();
	public static List<Vector2> lastSafePosP2 = new List<Vector2>();
	public static Dictionary<Vector2Int, TileType> tileTypeIndex = new Dictionary<Vector2Int, TileType>();
	public static LeverBehaviour lastLever;

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

	public static TileType WhichTileIsPlayerAt(Vector2 pos, int index)
	{
		TileType tileType;
		if(tileTypeIndex.TryGetValue(new Vector2Int((int)pos.x, (int)pos.y), out tileType))
			return tileType;
		else return Criogenia.TileType.Dry;
	}
}
