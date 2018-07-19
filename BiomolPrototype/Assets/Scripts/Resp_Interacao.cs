using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resp_Interacao : MonoBehaviour
{
    
    private GameObject player;
    public void set_player(GameObject plr) { player = plr; }
    public GameObject get_player() { return player; }

   
    public virtual void Acao()
    {
        
    }
    
}
