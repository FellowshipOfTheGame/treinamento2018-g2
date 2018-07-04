using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarOnOff : MonoBehaviour {

    private GameObject[] imas;

	// Use this for initialization
	void Start () {

        imas = GameObject.FindGameObjectsWithTag("Ima");

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.L)) {
            for (int i = 0; i < imas.Length; i++)
            {
                if(imas[i].GetComponent<Controle_Ima>().tipo == Controle_Ima.Tipo_Ima.Laranja)
                    imas[i].GetComponent<Controle_Ima>().ativo = !imas[i].GetComponent<Controle_Ima>().ativo;

            }
        }
    }
}
