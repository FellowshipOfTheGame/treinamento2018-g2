using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_Ima : MonoBehaviour {

    public enum Tipo_Ima { Verde, Laranja };

    public GameObject campo;
    public Tipo_Ima tipo;
    public float alcance = 3.0f;
    private Sprite sprite;
    private Sprite sprite_campo;
    public bool ativo = false;


    // Use this for initialization
    void Start() {

        if (tipo == Tipo_Ima.Verde) {
            sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima Ver");
            sprite_campo = Resources.Load<Sprite>("Magnetismo/Sprites/Campo");
        }
        else {
            sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima Lar");
            sprite_campo = Resources.Load<Sprite>("Magnetismo/Sprites/Campo");
        }

        campo.GetComponent<SpriteRenderer>().sprite = sprite_campo;
        GetComponent<SpriteRenderer>().sprite = sprite;

        campo.GetComponent<BoxCollider2D>().size = new Vector2(1, (float)alcance);
        campo.GetComponent<Transform>().parent.SetParent(GetComponent<Transform>());
        campo.GetComponent<Transform>().localPosition = new Vector2(0, -(float)(alcance / 2 + 0.5));
    }

        // Update is called once per frame
    void Update () {

        if (ativo == true)
            campo.SetActive(true);
        else
            campo.SetActive(false);

    }
}
