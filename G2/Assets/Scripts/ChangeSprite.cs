using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {
    private Sprite old;
    public Sprite change;
    void Start() {
        old = GetComponent<SpriteRenderer>().sprite;
    }
    private void TrocaSprite() {

        GetComponent<SpriteRenderer>().sprite = old;

    }
    public void NewSprite() {
        GetComponent<SpriteRenderer>().sprite = change;
        Invoke("TrocaSprite", 0.5f);
    }
    
}
