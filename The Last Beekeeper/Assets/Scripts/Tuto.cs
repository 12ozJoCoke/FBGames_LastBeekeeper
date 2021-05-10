using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    public Canvas tutoriel;
    public bool activate;
    
    void Start()
    {
        activate = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKey(KeyCode.T))
        {
            activate = true;
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
