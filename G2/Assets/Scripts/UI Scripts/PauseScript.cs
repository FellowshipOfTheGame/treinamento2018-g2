using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    private bool pause;
    public bool get_pause() { return pause; }

    public GameObject menu_pause;

    // Use this for initialization
    void Start()
    {
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause") || Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    public void Pause()
    {

        pause = !pause;

        if (pause == true)
        {
            Time.timeScale = 0;
            menu_pause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menu_pause.SetActive(false);
        }

    }
}