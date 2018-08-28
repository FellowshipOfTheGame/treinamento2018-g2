using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour {

	public bool isEnabled = true;

	private void OnEnable()
	{
		Criogenia.tileTypeIndex[Criogenia.GetIndex(this.transform.position)-1].Remove(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y));
		Criogenia.tileTypeIndex[Criogenia.GetIndex(this.transform.position)-1].Add(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y),Criogenia.TileType.Water);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" && isEnabled)
		{
			Debug.Log("You ded");
			other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			other.gameObject.transform.position = Criogenia.GetLastSafePos(other.GetComponent<Movimento_Player>().playerIndex);
			other.GetComponent<Movimento_Player>().isInControl = true;
		}
	}
}
