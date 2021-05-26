using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageFlip : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public Canvas Can;
    public bool SlideChange;

    // Start is called before the first frame update
    void Start()
    {
        Image1.active = true;
        Image2.active = false;
        Can.enabled = false;
        SlideChange = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!SlideChange)
            {
                SlideChange = true;
            }
            else
            {
                SlideChange = false;
            }
        }

        if (SlideChange)
        {
            Image1.active = false;
            Image2.active = true;
            Can.enabled = true;
        }
        else
        {
            Image1.active = true;
            Image2.active = false;
            Can.enabled = false;
        }
    }
}
