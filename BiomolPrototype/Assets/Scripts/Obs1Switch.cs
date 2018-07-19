using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs1Switch : Resp_Interacao {
    private bool fireUp = true;
    public GameObject door, fireWall;   
    private Sprite old;
    public Sprite change;

    void Start()
    {
        old = GetComponent<SpriteRenderer>().sprite;
    }
    public void TrocaSprite()
    {
        GetComponent<SpriteRenderer>().sprite = old;
    }
    public override void Acao()
    {
        GetComponent<SpriteRenderer>().sprite = change;
        Invoke("TrocaSprite", 0.5f);
        if (fireUp)
        {
            for(int i=0; i<6; i++)
            {
                fireWall.GetComponentsInChildren<SpriteRenderer>()[i].enabled = false;
            }
            fireWall.GetComponentsInParent<BoxCollider2D>()[0].enabled = false;
            fireWall.GetComponentsInParent<BoxCollider2D>()[1].enabled = false;
            door.GetComponentInChildren<SpriteRenderer>().enabled = true;
            door.GetComponentInParent<BoxCollider2D>().enabled = true;
            fireUp = false;
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                fireWall.GetComponentsInChildren<SpriteRenderer>()[i].enabled = true;
            }
            fireWall.GetComponentsInParent<BoxCollider2D>()[0].enabled = true;
            fireWall.GetComponentsInParent<BoxCollider2D>()[1].enabled = true;
            door.GetComponentInChildren<SpriteRenderer>().enabled = false;
            door.GetComponentInParent<BoxCollider2D>().enabled = false;
            fireUp = true;
        }

    }
}
