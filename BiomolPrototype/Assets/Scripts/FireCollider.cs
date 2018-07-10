using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour {
    private GameObject player1, clone;
    private bool isDone, fireUp=true;
    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
       

    }
    private void Update()
    {
        if (player1.GetComponent<PlayerController>().isCloned && !isDone)
        {
            clone = GameObject.FindGameObjectWithTag("Clone");
            isDone = true;
        }
        if (Input.GetKeyDown("f"))
        {
            if (fireUp)
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponentInParent<BoxCollider2D>().enabled = false;
                fireUp = false;
            }
            else
            {
                this.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
                this.gameObject.GetComponentInParent<BoxCollider2D>().enabled = true;
                fireUp = true;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player1.transform.position = new Vector3(-6,0,-1);

            if (clone != null)
            {
                Destroy(clone);
                player1.GetComponent<PlayerController>().isCloned = false;
                isDone = false;
                
            }
        }
        if (collision.CompareTag("Clone"))
        {
            Destroy(clone);
            player1.GetComponent<PlayerController>().isCloned = false;
            isDone = false;
        }
    }
    
}
