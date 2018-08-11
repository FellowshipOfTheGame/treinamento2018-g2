using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour {

	public bool isEnabled = true;

	private void Start()
	{
		Criogenia.tileTypeIndex.Add(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y),Criogenia.TileType.Water);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && isEnabled)
		{
			other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			other.gameObject.transform.position = Criogenia.lastSafePos[other.GetComponent<Movimento_Player>().playerIndex];
			other.GetComponent<Movimento_Player>().isInControl = true;
		}
	}
}
