using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    public Canvas tutoriel;
    public bool activate;
    public float timer;
    public float timetoexit;

    void Start()
    {
        activate = true;
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= timetoexit)
        {
            timer += Time.deltaTime;
        }

        else if (timer >= timetoexit)
        {
            activate = false;
        }

        if (Input.GetKey(KeyCode.T))
        {
            activate = true;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            activate = false;
        }

        if (!activate)
        {
            tutoriel.enabled = false;
        }
        else
        {
            tutoriel.enabled = true;
        }

        
    }
}
