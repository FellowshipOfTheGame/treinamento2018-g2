using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakableIceBehaviour : MonoBehaviour {

	private IceBehaviour iceBehaviour;
	private WaterBehaviour waterBehaviour;
	private BoxCollider2D collider;
	private SpriteRenderer renderer;

	[SerializeField]
	private Sprite breakableIce, brokenIce;
	private void Awake()
	{
		iceBehaviour = GetComponent<IceBehaviour>();
		waterBehaviour = GetComponent<WaterBehaviour>();
		collider = GetComponent<BoxCollider2D>();
		renderer = GetComponent<SpriteRenderer>();

		Regen();
	}
	
	private void OnEnable()
	{
		Criogenia.tileTypeIndex[Criogenia.GetIndex(this.transform.position)-1].Remove(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y));
		Criogenia.tileTypeIndex[Criogenia.GetIndex(this.transform.position)-1].Add(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y),Criogenia.TileType.Ice);
	}

	public void Break()
	{
		waterBehaviour.isEnabled = true;
		iceBehaviour.isEnabled = false;
		collider.size = new Vector2(0.7f,0.7f);
		renderer.sprite = brokenIce;
		Criogenia.tileTypeIndex[Criogenia.GetIndex(this.transform.position)-1].Remove(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y));
		Criogenia.tileTypeIndex[Criogenia.GetIndex(this.transform.position)-1].Add(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y),Criogenia.TileType.Water);
	}

	public void Regen()
	{
		waterBehaviour.isEnabled = false;
		iceBehaviour.isEnabled = true;
		collider.size = new Vector2(1,1);
		renderer.sprite = breakableIce;
		Criogenia.tileTypeIndex[Criogenia.GetIndex(this.transform.position)-1].Remove(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y));
		Criogenia.tileTypeIndex[Criogenia.GetIndex(this.transform.position)-1].Add(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y),Criogenia.TileType.Ice);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(iceBehaviour.isEnabled)
		{
			Break();
		}
	}

}
