using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ativacao : MonoBehaviour {

    //private bool ativado = false;
    
    //bool get_ativado() { return ativado; }

    static bool isActive = true;
    static int platAtivadas = 0;

    private void Start() {
        platAtivadas = 0;
        isActive = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Bola" && isActive)
        {
            platAtivadas++;
            Debug.Log(platAtivadas);
            if(platAtivadas >= 2)
            {
                GameManager.instance.CompletedPuzzles++;
                GameManager.instance.MagIcon.SetActive(true);
                isActive = false;
            }
        }
            //ativado = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Bola")
            platAtivadas--;
            Debug.Log(platAtivadas);
            //ativado = false;
    }

}
