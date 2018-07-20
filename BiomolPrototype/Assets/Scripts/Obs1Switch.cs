﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs1Switch : Resp_Interacao {
    private bool fireUp = true;
    public GameObject door, fireWall, bigFire;   
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

            fireWall.SetActive(false);
            bigFire.SetActive(true);
            door.SetActive(true);
            fireUp = false;
        }
        else
        {
            fireWall.SetActive(true);
            bigFire.SetActive(false);
            door.SetActive(false);
            fireUp = true;
        }

    }
}
