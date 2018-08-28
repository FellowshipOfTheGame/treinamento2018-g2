using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour {
    private GameObject clone, playerClone;
    public GameObject player1;

    private bool isDone=false;
    public GameObject initPos;

    private void Start()
    {
        player1 = GameObject.Find("Player1");  
    }

    private void Update()
    {
        if (player1.GetComponent<PlayerController>().isCloned && !isDone)
        {
            clone = GameObject.FindGameObjectWithTag("Clone");
            isDone = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player1.transform.position = initPos.transform.position;

            if (clone != null)
            {
                Destroy(clone);
                player1.GetComponent<PlayerController>().isCloned = false;
                isDone = false;
                
            }
        }
        if (collision.CompareTag("Clone"))
        {
            Destroy(collision.gameObject);
            player1.GetComponent<PlayerController>().isCloned = false;
            isDone = false;

        }
    }
    
}
