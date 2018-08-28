using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSwitcher : Resp_Interacao {

    public GameObject[] onObjects, offObjects;
    private bool isSwitched = false;

    public override void Acao() {
        Debug.Log("Yo");
        if (!isSwitched) {
            foreach(GameObject onG in onObjects) {
                onG.SetActive(false);
            }
            foreach(GameObject offG in offObjects) {
                offG.SetActive(true);
            }
            isSwitched = true;
        }
        else {
            foreach (GameObject onG in onObjects) {
                onG.SetActive(true);
            }
            foreach (GameObject offG in offObjects) {
                offG.SetActive(false);
            }
            isSwitched = false;
        }
    }
}
