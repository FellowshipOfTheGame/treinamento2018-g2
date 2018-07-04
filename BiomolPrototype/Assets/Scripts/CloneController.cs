using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour {
    public float velocidade;

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movimento = new Vector2(-moveHorizontal,-moveVertical);
        GetComponent<Rigidbody>().velocity = movimento * velocidade;
    }
}
