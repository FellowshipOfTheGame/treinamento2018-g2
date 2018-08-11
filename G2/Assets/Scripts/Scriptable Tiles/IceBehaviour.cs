using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceBehaviour : MonoBehaviour {

	Vector2 playerSpeed;

	[SerializeField]
	private float speed, offsetSpeed;
	private bool hasStopped = false;
	private enum Direction {Left, Right, Up, Down};
	private Direction direction;
	public int index;
	private GameObject currentPlayer;
	public bool isEnabled = true;

	void Start()
	{
		if(transform.position.x < GameObject.Find("Criogenia").transform.position.x)
			index = 1;
		else
			index = 2;

		Criogenia.tileTypeIndex.Add(new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y),Criogenia.TileType.Ice);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player") && isEnabled)
		{
			currentPlayer = other.gameObject;
			hasStopped = false;
			other.gameObject.GetComponent<Movimento_Player>().isInControl = false;
			playerSpeed = other.gameObject.GetComponent<Rigidbody2D>().velocity;

			if(currentPlayer.GetComponent<Movimento_Player>().playerIndex == 1)
				isPlayer1OnIce = true;
			else
				isPlayer2OnIce = true;
				
			if(playerSpeed != Vector2.zero)
			{
				if(Mathf.Abs(playerSpeed.x) >= Mathf.Abs(playerSpeed.y))
				{
					if(playerSpeed.x > 0)
						direction = Direction.Right;
					else
						direction = Direction.Left;

					playerSpeed = new Vector2(speed * Mathf.Sign(playerSpeed.x),0);
				}
				else if(Mathf.Abs(playerSpeed.y) > Mathf.Abs(playerSpeed.x))
				{
					if(playerSpeed.y > 0)
						direction = Direction.Up;
					else
						direction = Direction.Down;
						
					playerSpeed = new Vector2(0,speed * Mathf.Sign(playerSpeed.y));
				}
			}

			other.gameObject.GetComponent<Rigidbody2D>().velocity = playerSpeed;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player") && isEnabled)
		{
			if(currentPlayer.GetComponent<Movimento_Player>().playerIndex == 1)
				isPlayer1OnIce = true;
			else
				isPlayer2OnIce = true;

			Vector2 currentSpeed = other.gameObject.GetComponent<Rigidbody2D>().velocity;
			//other.gameObject.GetComponent<PlayerController>().isInControl = false;
			if(currentSpeed == Vector2.zero)
			{
				hasStopped = true;
				other.gameObject.GetComponent<Movimento_Player>().isInControl = true;
			}
			else
			{
				if(hasStopped)
				{
					OnTriggerEnter2D(other);
					hasStopped = false;
				}
				if(!hasStopped)
				{
					Vector3 centerPoint;
					if(direction == Direction.Up || direction == Direction.Down)
						centerPoint = new Vector3((int)this.transform.position.x + Mathf.Sign(this.transform.position.x) * 0.5f,other.transform.position.y,0);
					else
						centerPoint = new Vector3(other.transform.position.x,(int)this.transform.position.y + Mathf.Sign(this.transform.position.y) * 0.5f,0);

					other.transform.position = Vector3.MoveTowards(other.transform.position, centerPoint, offsetSpeed);
					currentSpeed = playerSpeed;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player") && isEnabled)
		{
			if(currentPlayer.GetComponent<Movimento_Player>().playerIndex == 1)
				isPlayer1OnIce = false;
			else
				isPlayer2OnIce = false;
		}
	}

	private void OnDisable()
	{
		if(currentPlayer != null)
			if(currentPlayer.GetComponent<Movimento_Player>().playerIndex == 1)
				isPlayer1OnIce = false;
			else
				isPlayer2OnIce = false;
	}
}
