using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public List<Canvas> OnWhenPaused, OffWhenPaused;
    public bool IsPaused;
    // Start is called before the first frame update
    void Start()
    {
        IsPaused = false;

        foreach (Canvas thing in OnWhenPaused)
        {
            thing.gameObject.SetActive(IsPaused);
        }
        foreach (Canvas thing2 in OffWhenPaused)
        {
            thing2.gameObject.SetActive(!IsPaused);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = Convert.ToInt32(!IsPaused);
        Debug.Log("Time Scale: " + Time.timeScale);

        foreach (Canvas thing in OnWhenPaused)
        {
            thing.gameObject.SetActive(IsPaused);
        }
        foreach (Canvas thing2 in OffWhenPaused)
        {
            thing2.gameObject.SetActive(!IsPaused);
        }
    }
}
