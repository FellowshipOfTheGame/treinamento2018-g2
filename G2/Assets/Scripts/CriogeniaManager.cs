using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class CriogeniaManager : MonoBehaviour {
	
		[SerializeField]private GameObject Ice1, Ice2, Water1, Water2, BreakableIce1, BreakableIce2;
	

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.H))
			Criogenia.SwapRoomTemp(1);
		if(Input.GetKeyDown(KeyCode.B))
			Criogenia.SwapRoomTemp(2);
	}

	public void SwapTemperature(int index, Criogenia.Temperature temperature)
	{
		foreach(var player in GameObject.FindGameObjectsWithTag("Player"))
			if(player.GetComponent<Movimento_Player>().playerIndex == index)
			{
				player.GetComponent<Movimento_Player>().isInControl = true;
				player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			}

		if(temperature == Criogenia.Temperature.Cold)
		{
			if(index == 1)
			{
				Ice1.SetActive(false);
				Water1.SetActive(true);
				foreach (var tile in BreakableIce1.GetComponentsInChildren<BreakableIceBehaviour>())
					tile.Break();

			}
			else if(index == 2)
			{
				Ice2.SetActive(false);
				Water2.SetActive(true);
				foreach (var tile in BreakableIce2.GetComponentsInChildren<BreakableIceBehaviour>())
					tile.Break();
			}
		}
		else if(temperature == Criogenia.Temperature.Hot)
		{
			if(index == 1)
			{
				Ice1.SetActive(true);
				Water1.SetActive(false);
				foreach (var tile in BreakableIce1.GetComponentsInChildren<BreakableIceBehaviour>())
					tile.Regen();
			}
			else if(index == 2)
			{
				Ice2.SetActive(true);
				Water2.SetActive(false);
				foreach (var tile in BreakableIce2.GetComponentsInChildren<BreakableIceBehaviour>())
					tile.Regen();
			}
		}
	}

	public void EndGame()
	{
		Debug.Log("YouWin");
	}
}
