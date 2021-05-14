using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisapper : MonoBehaviour
{
    public GameObject text;

    public float timer;
    public float timetoexit;
    void Start()
    {
        text.SetActive(true);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= timetoexit)
        {
            timer += Time.deltaTime;
        }

        else if(timer >= timetoexit)
        {
            text.SetActive(false);
        }
    }
}
