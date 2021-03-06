﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimento_Player : MonoBehaviour
{

    public enum Orientacao { Cima, Baixo, Direita, Esquerda };


    public float velocidade = 2;                        //magnitude da velocidade  
    private float angulo;                               //angulo do movimento
    private bool correndo = false;
    private Rigidbody2D rb;
    private Orientacao orientacao;
    public Orientacao get_orientacao() { return orientacao; }
    public bool isInControl = true;
    public int playerIndex;
    public Animator animator;

    public string Correr, Horizontal, Vertical;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        playerIndex = Criogenia.GetIndex(this.transform.position);

        // Verifica se o player pode se mover/interagir
        if(isInControl)
        {
            if(rb.velocity == Vector2.zero)
            {
                Criogenia.lastSafePosList[playerIndex-1].Push(this.gameObject.transform.position);
            }
            //MOVIMENTO
            rb.velocity = new Vector2(Input.GetAxis(Horizontal) * velocidade, Input.GetAxisRaw(Vertical) * velocidade); //define a componente velocity a partir de um vetor
           
            //if(rb.velocity.magnitude > velocidade)
            //    rb.velocity = rb.velocity.normalized * velocidade;

            if (rb.velocity.magnitude != 0f)                                               //analisa o angulo em que o personagem
            {                                                                              //se move, indo de 0 a 359 graus
                if (Input.GetAxis(Vertical) >= 0)                                      
                    angulo = Vector2.Angle(new Vector2(1, 0), rb.velocity);              
                else if (Input.GetAxis(Vertical) < 0)
                    angulo = 360 - Vector2.Angle(new Vector2(1, 0), rb.velocity);
            }

            //CONTROLE DA ORIENTAÇÃO
            if (angulo <= 60 || angulo >= 300)                                      //muda o valor da variavel orientacao
                orientacao = Orientacao.Direita;                                    //dependendo do angulo em que
            else if (angulo > 60 && angulo < 120)                                   //o personagem se move
                orientacao = Orientacao.Cima;
            else if (angulo >= 120 && angulo <= 250)
                orientacao = Orientacao.Esquerda;
            else
                orientacao = Orientacao.Baixo;

            animator.SetFloat("SpeedVertical", Mathf.Abs(rb.velocity.y));
            animator.SetFloat("SpeedHorizontal", Mathf.Abs(rb.velocity.x));
            animator.SetInteger("Orientation", (int)orientacao);

            //CORRER
            if (correndo == false)
            {

                if (Input.GetButtonDown(Correr) && rb.velocity.magnitude != 0f)
                {
                    velocidade *= 1.5f;
                    correndo = true;
                }

            }
            else
            {

                if (Input.GetButtonUp(Correr) || rb.velocity.magnitude == 0f)
                {
                    velocidade /= 1.5f;
                    correndo = false;
                }
            }
        }
        else
        {
            if((Criogenia.WhichTileIsPlayerAt(this.gameObject.transform.position, playerIndex) == Criogenia.TileType.Dry && playerIndex == 1) ||
            (Criogenia.WhichTileIsPlayerAt(this.gameObject.transform.position, playerIndex) == Criogenia.TileType.Dry && playerIndex == 2))
            {
                Debug.Log("Stop.");
                rb.velocity = Vector2.zero;
                isInControl = true;
            }

        }
    }
}