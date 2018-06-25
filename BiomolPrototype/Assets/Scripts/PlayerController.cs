using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocidade;
    public bool isCloned=false;
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movimento = new Vector2(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movimento * velocidade;
    }
}
