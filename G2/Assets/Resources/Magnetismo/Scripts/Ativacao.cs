using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativacao : MonoBehaviour {

    //private bool ativado = false;
    
    //bool get_ativado() { return ativado; }

    static bool isActive = true;
    static int platAtivadas = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Bola" && isActive)
        {
            platAtivadas++;
            if(platAtivadas == 2)
            {
                GameManager.instance.CompletedPuzzles++;
                isActive = false;
            }
        }
            //ativado = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Bola")
            platAtivadas--;
            //ativado = false;
    }

}
