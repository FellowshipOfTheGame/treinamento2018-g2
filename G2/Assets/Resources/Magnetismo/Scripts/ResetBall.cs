using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour {


    private float initial_x;
    private float initial_y;

	// Use this for initialization
	void Start () {

        initial_x = GetComponent<Transform>().position.x;
        initial_y = GetComponent<Transform>().position.y;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyUp(KeyCode.R))
        {
            //GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Transform>().position = new Vector2(initial_x, initial_y);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }

	}
}
