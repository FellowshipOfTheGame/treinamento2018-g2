using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativacao : MonoBehaviour {

    private bool ativado = false;
    bool get_ativado() { return ativado; }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Bola")
            ativado = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Bola")
            ativado = false;
    }

}
