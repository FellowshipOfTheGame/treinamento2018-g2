using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsRedController : Resp_Interacao {
    public GameObject laser, fireDoor;
    private Sprite old;
    public Sprite change;
    private bool fireUp=true;

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
            fireDoor.SetActive(false);
            laser.SetActive(true);
            fireUp = false;
        }
        else
        {
            fireDoor.SetActive(true);
            laser.SetActive(false);
            fireUp = true;
        }
    }

}
