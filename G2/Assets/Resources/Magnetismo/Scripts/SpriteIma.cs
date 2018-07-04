using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteIma : MonoBehaviour {

   /* Sprite sprite;

    SpriteRenderer sprRen;
    Controle_Ima.Tipo_Ima tipo_Ima;
    Controle_Ima ctrlIma;
    bool ativo;
    float angulo;

    // Use this for initialization
    void Start()
    {

        sprRen = GetComponent<SpriteRenderer>();
        tipo_Ima = GetComponent<Controle_Ima>().tipo;
        angulo = GetComponent<Transform>().rotation.z;
        ativo = GetComponent<Controle_Ima>().ativo;

        switch (tipo_Ima)
        {

            case Controle_Ima.Tipo_Ima.Laranja:

                if (gameObject.name == "Ima")
                    Debug.Log("angulo = " + (int)angulo);

                switch ((int)angulo)
                {

                    case 0:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Lar_Fre");
                        break;

                    case 90:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Lar_Dir");
                        break;

                    case 180:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Lar_Tras");
                        break;

                    case -90:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Lar_Esq");
                        break;
                }
                break;

            case Controle_Ima.Tipo_Ima.Verde:

                switch ((int)angulo)
                {

                    case 0:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Ver_Fre");
                        break;

                    case 90:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Ver_Dir");
                        break;

                    case 180:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Ver_Tras");
                        break;

                    case -90:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Ver_Esq");
                        break;
                }
                break;

            case Controle_Ima.Tipo_Ima.Vermelho:

                switch ((int)angulo)
                {

                    case 0:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Red_Fre");
                        break;

                    case 90:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Red_Dir");
                        break;

                    case 180:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Red_Tras");
                        break;

                    case -90:

                        sprite = Resources.Load<Sprite>("Magnetismo/Sprites/Ima_Red_Esq");
                        break;
                }
                break;

        }

        sprRen.sprite = sprite;

    }*/
}
