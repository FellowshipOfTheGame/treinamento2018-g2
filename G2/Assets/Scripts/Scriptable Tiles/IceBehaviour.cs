using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceBehaviour : MonoBehaviour {

	Vector2 playerSpeed;

	[SerializeField]
	private float speed, offsetSpeed;
	private bool hasStopped = false;
	private enum Direction {Horizontal, Vertical};
	private Direction direction;
	public int index;

	void Start()
	{
		if(transform.position.x < GameObject.Find("Criogenia").transform.position.x)
			index = 1;
		else
			index = 2;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			hasStopped = false;
			other.gameObject.GetComponent<PlayerController>().isInControl = false;
			playerSpeed = other.gameObject.GetComponent<Rigidbody2D>().velocity;

			if(Mathf.Abs(playerSpeed.x) >= Mathf.Abs(playerSpeed.y))
			{
				direction = Direction.Horizontal;
				playerSpeed = new Vector2(speed * Mathf.Sign(playerSpeed.x),0);
			}
			else if(Mathf.Abs(playerSpeed.y) > Mathf.Abs(playerSpeed.x))
			{
				direction = Direction.Vertical;
				playerSpeed = new Vector2(0,speed * Mathf.Sign(playerSpeed.y));
			}

			other.gameObject.GetComponent<Rigidbody2D>().velocity = playerSpeed;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Vector2 currentSpeed = other.gameObject.GetComponent<Rigidbody2D>().velocity;
			//other.gameObject.GetComponent<PlayerController>().isInControl = false;
			if(currentSpeed == Vector2.zero)
			{
				hasStopped = true;
				other.gameObject.GetComponent<PlayerController>().isInControl = true;
			}
			else
			{
				//if(hasStopped)
				//{
				//	OnTriggerEnter2D(other);
				//	hasStopped = false;
				//}
				if(!hasStopped)
				{
					Vector3 centerPoint;
					if(direction == Direction.Vertical)
						centerPoint = new Vector3(this.transform.position.x + 0.5f,other.transform.position.y,0);
					else
						centerPoint = new Vector3(other.transform.position.x,this.transform.position.y + 0.5f);

					other.transform.position = Vector3.MoveTowards(other.transform.position, centerPoint, offsetSpeed);
					currentSpeed = playerSpeed;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Tilemap tilemap = GameObject.Find("Ice" + index).GetComponent<Tilemap>();
			//if(tilemap.GetTile(tilemap.WorldToCell(other.transform.position)))
			//	other.gameObject.GetComponent<PlayerController>().isInControl = true;
			foreach(var tile in GameObject.FindGameObjectsWithTag("Tile"))
			{
				if(tile.GetComponent<IceBehaviour>())
					if(tilemap.WorldToCell(tile.transform.position) == tilemap.WorldToCell(other.transform.position))
						return;
			}
			other.gameObject.GetComponent<PlayerController>().isInControl = true;
		}
	}
}
