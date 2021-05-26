using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageFlip : MonoBehaviour
{
    public List<GameObject> images;
    public Canvas Can;
    public bool SlideChange;
    int ActivePage;

    // Start is called before the first frame update
    void Start()
    {
        ActivePage = 0;
        foreach (GameObject page in images)
        {
            page.SetActive(false);
        }
        images[ActivePage].SetActive(true);
        SlideChange = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            images[ActivePage].SetActive(false);
            ActivePage++;
            if (ActivePage > (images.Count - 1))
            {
                ActivePage = 0;
            }
            images[ActivePage].SetActive(true);
        }
    }
}
