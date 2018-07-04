using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed;
	public bool isInControl = true;
	private Vector3 lastKnownPos = new Vector3(0,0,1);

	// Update is called once per frame
	void Update () {
		if(isInControl)
			GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed,Input.GetAxis("Vertical") * speed);
		if(GetComponent<Rigidbody2D>().velocity == Vector2.zero)
		{
			gameObject.GetComponent<PlayerController>().isInControl = true;
		}
	}
}
