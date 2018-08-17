using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{

    public float distancia = 2;                   //quão distante é possivel interagir com os objetos
    private RaycastHit2D hit;
    private float angulo;
    private Vector2 ray_direction;
    private Movimento_Player.Orientacao orientacao;
    private Resp_Interacao resp_int;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        orientacao = GetComponent<Movimento_Player>().get_orientacao();         //pega a orientaçao atual do player

        if (orientacao == Movimento_Player.Orientacao.Direita)                  //muda a direção do ray_direction
            ray_direction = Vector2.right;                                      //dependendo da orientação atual
        else if (orientacao == Movimento_Player.Orientacao.Cima)
            ray_direction = Vector2.up;
        else if (orientacao == Movimento_Player.Orientacao.Esquerda)
            ray_direction = Vector2.left;
        else
            ray_direction = Vector2.down;

        hit = Physics2D.Raycast(transform.position, ray_direction, distancia);  //"executa" o ray_cast

        if (Input.GetButtonDown("Interagir"))
        {

            Debug.Log(ray_direction.ToString());
            if (hit.collider != null)
            {

                resp_int = hit.collider.GetComponent(typeof(Resp_Interacao)) as Resp_Interacao;
                Debug.Log(hit.collider.name);
                resp_int.set_player(gameObject);


                resp_int.Acao();

                

            }
        }
        
            

    }
}