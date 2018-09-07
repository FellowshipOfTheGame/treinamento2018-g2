using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;

public class CriogeniaManager : MonoBehaviour {
	
	[SerializeField] private GameObject Ice1, Ice2, Water1, Water2, BreakableIce1, BreakableIce2;
	bool isActive = true;
	
	private void Awake() {

		(Ice1 = GameObject.Find("Ice1")).SetActive(false);
		(Ice2 = GameObject.Find("Ice2")).SetActive(false);
		BreakableIce1 = GameObject.Find("BreakableIce1");
		BreakableIce2 = GameObject.Find("BreakableIce2");
		(Water1 = GameObject.Find("Water1")).SetActive(false);
		(Water2 = GameObject.Find("Water2")).SetActive(false);

		Criogenia.Initialize();
	}

	private void Start() {
		
		SwapTemperature(1, Criogenia.Temperature.Hot);
		SwapTemperature(2, Criogenia.Temperature.Hot);

		GameManager.instance.ElevatorDoor = GameObject.Find("ElevatorDoor");
		GameManager.instance.InitGame();
	}

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
				if(Ice1 != null)
					Ice1.SetActive(false);
				if(Water1 != null)
					Water1.SetActive(true);
				if(BreakableIce1 != null)
					foreach (var tile in BreakableIce1.GetComponentsInChildren<BreakableIceBehaviour>())
						tile.Break();

			}
			else if(index == 2)
			{
				if(Ice2 != null)
					Ice2.SetActive(false);
				if(Water2 != null)
					Water2.SetActive(true);
				if(BreakableIce2 != null)
					foreach (var tile in BreakableIce2.GetComponentsInChildren<BreakableIceBehaviour>())
						tile.Break();
			}
		}
		else if(temperature == Criogenia.Temperature.Hot)
		{
			if(index == 1)
			{
				if(Ice1 != null)
					Ice1.SetActive(true);
				if(Water1 != null)
					Water1.SetActive(false);
				if(BreakableIce1 != null)
					foreach (var tile in BreakableIce1.GetComponentsInChildren<BreakableIceBehaviour>())
						tile.Regen();
			}
			else if(index == 2)
			{
				if(Ice2 != null)
					Ice2.SetActive(true);
				if(Water2 != null)
					Water2.SetActive(false);
				if(BreakableIce2 != null)
					foreach (var tile in BreakableIce2.GetComponentsInChildren<BreakableIceBehaviour>())
						tile.Regen();
			}
		}
	}

	public void EndGame()
	{
		if(isActive)
		{
			isActive = false;
			GameManager.instance.CompletedPuzzles++;
			GameManager.instance.CrioIcon.SetActive(true);
		}
	}
}
