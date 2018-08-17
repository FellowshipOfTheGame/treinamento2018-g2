using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_Ima : MonoBehaviour {

    public enum Tipo_Ima { Verde, Laranja, Vermelho, Roxo };

    public GameObject campo;
    public Tipo_Ima tipo;
    public float alcance = 3.0f;
    private Sprite sprite;
    private Sprite sprite_campo;
    public bool ativo = false;


    // Use this for initialization
    void Start() {

        campo.GetComponent<BoxCollider2D>().size = new Vector2(0.9f, alcance-0.1f);
        campo.GetComponent<Transform>().parent.SetParent(GetComponent<Transform>());
        campo.GetComponent<Transform>().localPosition = new Vector2(0, -(float)(alcance / 2 + 0.5));
        campo.GetComponent<SpriteRenderer>().size = new Vector2(1, alcance);
        
    }

        // Update is called once per frame
    void Update () {

        if (ativo == true)
            campo.SetActive(true);
        else
            campo.SetActive(false);

    }
}
