using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CriogeniaManager : MonoBehaviour {

	[SerializeField]
	private Tile[] iceWater = new Tile[2], frozenGround = new Tile[2], breakIce = new Tile[2];
	private Tilemap tilemap1;
	private Tilemap tilemap2;

	void Awake()
	{
		tilemap1 = GameObject.Find("Ice1").GetComponent<Tilemap>();
		tilemap2 = GameObject.Find("Ice2").GetComponent<Tilemap>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.H))
			Criogenia.SwapRoomTemp(1);
		if(Input.GetKeyDown(KeyCode.H))
			Criogenia.SwapRoomTemp(2);
	}

	public void SwapTemperature(int index, Criogenia.Temperature temperature)
	{
		if(temperature == Criogenia.Temperature.Cold)
		{
			if(index == 1)
			{
				foreach(var tile in GameObject.FindGameObjectsWithTag("Tile"))
				{
					if(tile.GetComponent<Transform>().parent.gameObject == tilemap1.gameObject)
						Destroy(tile);
				}
				tilemap1.SwapTile(iceWater[0],iceWater[1]);
				tilemap1.SwapTile(frozenGround[0],frozenGround[1]);
				tilemap1.SwapTile(breakIce[0],breakIce[1]);
				tilemap1.RefreshAllTiles();
			}
			else if(index == 2)
			{
				foreach(var tile in GameObject.FindGameObjectsWithTag("Tile"))
				{
					if(tile.GetComponent<Transform>().parent.gameObject == tilemap2.gameObject)
						Destroy(tile);
				}
				tilemap2.SwapTile(iceWater[0],iceWater[1]);
				tilemap2.SwapTile(frozenGround[0],frozenGround[1]);
				tilemap2.SwapTile(breakIce[0],breakIce[1]);
				tilemap2.RefreshAllTiles();
			}
		}
		else if(temperature == Criogenia.Temperature.Hot)
		{
			if(index == 1)
			{
				foreach(var tile in GameObject.FindGameObjectsWithTag("Tile"))
				{
					if(tile.GetComponent<Transform>().parent.gameObject == tilemap1.gameObject)
						Destroy(tile);
				}
				tilemap1.SwapTile(iceWater[1],iceWater[0]);
				tilemap1.SwapTile(frozenGround[1],frozenGround[0]);
				tilemap1.SwapTile(breakIce[1],breakIce[0]);
			}
			else if(index == 2)
			{
				foreach(var tile in GameObject.FindGameObjectsWithTag("Tile"))
				{
					if(tile.GetComponent<Transform>().parent.gameObject == tilemap2.gameObject)
						Destroy(tile);
				}
				tilemap2.SwapTile(iceWater[1],iceWater[0]);
				tilemap2.SwapTile(frozenGround[1],frozenGround[0]);
				tilemap2.SwapTile(breakIce[1],breakIce[0]);
			}
		}
	}
}
