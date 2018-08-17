using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollider : MonoBehaviour {

    public float delay;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.CompareTag("Player1") || collision.CompareTag("Clone")){
            collision.GetComponent<Movimento_Player>().enabled = false;            
            StartCoroutine(Paralize(collision));
        }

    }
   private IEnumerator Paralize(Collider2D col)
    {
            yield return new WaitForSeconds(delay);
            col.GetComponent<Movimento_Player>().enabled = true;
          
    }
}
