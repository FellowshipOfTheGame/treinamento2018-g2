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
  
	public void Break()
	{
		waterBehaviour.isEnabled = true;
		iceBehaviour.isEnabled = false;
		collider.size = new Vector2(0.7f,0.7f);
		renderer.sprite = brokenIce;
	}

	public void Regen()
	{
		waterBehaviour.isEnabled = false;
		iceBehaviour.isEnabled = true;
		collider.size = new Vector2(1,1);
		renderer.sprite = breakableIce;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(iceBehaviour.isEnabled)
		{
			Break();
		}
	}

}
