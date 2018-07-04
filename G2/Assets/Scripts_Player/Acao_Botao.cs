using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acao_Botao : Resp_Interacao {

    public override void Acao()
    {
        get_player().GetComponent<Transform>().position = new Vector2(0, 0);
    }


    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
