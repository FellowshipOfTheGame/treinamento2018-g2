using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour {
    public float velocidade;

    private OpenDoor1 op;
    private void Start()
    {
        op = GameObject.FindGameObjectWithTag("GameController").GetComponent<OpenDoor1>();

    }

    private void Update()
    {
        if (op.isOpen)
        {
            Destroy(this.gameObject);
        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movimento = new Vector2(-moveHorizontal,-moveVertical);
        GetComponent<Rigidbody2D>().velocity = movimento * velocidade;
    }
}
