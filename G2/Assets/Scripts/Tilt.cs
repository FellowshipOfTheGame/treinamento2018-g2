using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour {

	void Update () {
		
		if(Input.GetKeyDown(KeyCode.T))
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)), ForceMode2D.Impulse);
			Invoke("TiltEnd", 0.1f);
		}

	}

	void TiltEnd()
	{

			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
}
