using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour {
    private GameObject clone;
    public GameObject player1;
    private bool isDone=false;
    public Vector3 initPos;

   

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
        if (collision.CompareTag("Player1"))
        {
            player1.transform.position = initPos;

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
