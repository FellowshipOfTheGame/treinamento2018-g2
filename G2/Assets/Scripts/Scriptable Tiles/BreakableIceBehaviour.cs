using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakableIceBehaviour : MonoBehaviour {

	[SerializeField]
	private Tile waterTile;
	public int index;

	void Start()
	{
		if(transform.position.x < GameObject.Find("Criogenia").transform.position.x)
			index = 1;
		else
			index = 2;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			Tilemap tilemap = GameObject.Find("Ice" + index).GetComponent<Tilemap>();
			GridLayout gridLayout = GameObject.Find("Grid").GetComponent<GridLayout>();

			tilemap.SetTile(gridLayout.WorldToCell(this.transform.position), waterTile);
			Destroy(this.gameObject);
		}
	}
}
