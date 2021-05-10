using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisapper : MonoBehaviour
{
    public Text text;

    public float timer;
    public float timetoexit;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= timetoexit)
        {
            
        }

        else if(timer >= timetoexit)
        {
            
        }
    }
}
