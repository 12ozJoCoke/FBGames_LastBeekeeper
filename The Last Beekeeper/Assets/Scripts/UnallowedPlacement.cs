using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnallowedPlacement : MonoBehaviour
{
    public GameObject player;
    Barier_making aaa;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        aaa = player.GetComponent<Barier_making>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnMouseOver()
    {
        aaa.CanPlace = false;
    }

    void OnMouseExit()
    {
        aaa.CanPlace = true;
    }
}
