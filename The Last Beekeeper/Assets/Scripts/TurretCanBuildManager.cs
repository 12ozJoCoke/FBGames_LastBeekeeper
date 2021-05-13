using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCanBuildManager : MonoBehaviour
{
    public Player_TurretConstruction ptc;
    SpriteRenderer sr;
    public Color unhighighted, highlighted;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        ptc.CanBuild = false;
        sr.color = highlighted;
    }

    private void OnMouseExit()
    {
        ptc.CanBuild = true;
        sr.color = unhighighted;
    }
}
