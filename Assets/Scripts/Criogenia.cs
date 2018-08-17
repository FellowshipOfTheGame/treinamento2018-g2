using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class Criogenia{

	public enum Temperature {Hot,Cold};
	public static Temperature room1Temp, room2Temp;
	public enum TileType {Ice, Water, Dry};
	private static CriogeniaManager manager = GameObject.Find("Criogenia").GetComponent<CriogeniaManager>();
	private static Stack<Vector2> p1LastSafePosList = new Stack<Vector2>(), p2LastSafePosList = new Stack<Vector2>();
	public static Stack<Vector2>[] lastSafePosList = new Stack<Vector2>[] {p1LastSafePosList, p2LastSafePosList};
	private static Dictionary<Vector2Int, TileType> tileTypeIndex1 = new Dictionary<Vector2Int, TileType>(), tileTypeIndex2 = new Dictionary<Vector2Int, TileType>();
	public static Dictionary<Vector2Int, TileType>[] tileTypeIndex = new Dictionary<Vector2Int, TileType>[2] {tileTypeIndex1, tileTypeIndex2};
	public static List<LeverBehaviour> leverLayout = new List<LeverBehaviour>();
	public static GameObject criogenia = GameObject.Find("Criogenia");

	public static void SwapRoomTemp(int index)
	{
		if(index == 1)
		{
			if(room1Temp == Temperature.Cold)
				room1Temp = Temperature.Hot;
			else
				room1Temp = Temperature.Cold;

			tileTypeIndex[0].Clear();

			manager.SwapTemperature(index,room1Temp);
		}
		else if(index == 2)
		{
			if(room2Temp == Temperature.Cold)
				room2Temp = Temperature.Hot;
			else
				room2Temp = Temperature.Cold;

			tileTypeIndex[1].Clear();

			manager.SwapTemperature(index,room2Temp);
		}
	}

	public static TileType WhichTileIsPlayerAt(Vector2 pos, int index)
	{
		TileType tileType;
		if(tileTypeIndex[index-1].TryGetValue(new Vector2Int((int)pos.x, (int)pos.y), out tileType))
			return tileType;
		else return Criogenia.TileType.Dry;
	}

	public static Vector2 GetLastSafePos(int index)
	{
		Vector2 lastSafePos = new Vector2();

		foreach(var pos in lastSafePosList[index-1])
		{
			if(WhichTileIsPlayerAt(pos, index) == TileType.Dry)
			{
				lastSafePos = pos;
				return pos;
			}
		}
		
		Debug.Log("Something went wrong with the last safe pos.");
		return lastSafePos;
	}

	public static int GetIndex(Vector2 pos)
	{
		if(pos.x <= criogenia.transform.position.x)
			return 1;
		else
			return 2;
	}

	public static void CheckWinCondition()
	{
		foreach(var lever in leverLayout)
			if(lever.currentState == false)
				return;
		manager.EndGame();
	}

}
