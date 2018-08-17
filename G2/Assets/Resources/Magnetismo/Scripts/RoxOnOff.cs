using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoxOnOff : Resp_Interacao
{

    private GameObject[] imas;

    private Sprite sprite_on;
    private Sprite sprite_off;

    private SpriteRenderer sprRen;

    // Use this for initialization
    void Start()
    {

        imas = GameObject.FindGameObjectsWithTag("Ima");

        sprRen = GetComponent<SpriteRenderer>();

        sprite_on = Resources.Load<Sprite>("Magnetismo/Sprites/Props/clicado_rox");// as Sprite;
        sprite_off = Resources.Load<Sprite>("Magnetismo/Sprites/Props/normal_rox");// as Sprite;

    }


    override public void Acao()
    {

        for (int i = 0; i < imas.Length; i++)
        {
            if (imas[i].GetComponent<Controle_Ima>().tipo == Controle_Ima.Tipo_Ima.Roxo)
                imas[i].GetComponent<Controle_Ima>().ativo = !imas[i].GetComponent<Controle_Ima>().ativo;

        }

        sprRen.sprite = sprite_on;

        Invoke("ResetSprite", 1);

    }

    void ResetSprite()
    {

        sprRen.sprite = sprite_off;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
            Acao();
    }
}
