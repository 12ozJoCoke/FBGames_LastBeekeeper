using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier_making : MonoBehaviour
{
    public int BarrierAmount, MaxAmount;
    public GameObject BarrierPre;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BarrierAmount >= MaxAmount)
        {
            BarrierAmount = MaxAmount;
        }
        else if(BarrierAmount <= 0)
        {
            BarrierAmount = 0;
        }

        if (Input.GetKey(KeyCode.E))
        {
            if(BarrierAmount > 0)
            {
                Instantiate(BarrierPre);
                BarrierAmount--;
            }
            else
            {
                Debug.Log("Ran out of barriers");
            }
           
        }
    }
    
}
