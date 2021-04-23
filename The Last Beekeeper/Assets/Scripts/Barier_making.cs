using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier_making : MonoBehaviour
{
    public int BarrierAmount, MaxAmount;
    public GameObject BarrierPre;
    public int SpikeAmount, MaxSpikeAmount;
    public GameObject SpikePre;
    private GameObject Player;
    public bool CanPlace;
    void Start()
    {
        Player = gameObject;
        CanPlace = true;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (BarrierAmount > 0 && !!CanPlace)
            {
                Instantiate(BarrierPre, transform.position, Quaternion.identity);

                BarrierAmount--;
            }
            else if (BarrierAmount > 0 && !CanPlace)
            {
                Debug.Log("Cannot place barrier here");
            }
            else
            {
                Debug.Log("Ran out of barriers");
            }

            
            }
        if (SpikeAmount >= MaxSpikeAmount)
        {
            SpikeAmount = MaxSpikeAmount;
        }
        else if (SpikeAmount <= 0)
        {
            SpikeAmount = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (SpikeAmount > 0 && !!CanPlace)
            {
                Instantiate(SpikePre, transform.position, Quaternion.identity);

                SpikeAmount--;
            }
            else if (SpikeAmount > 0 && !CanPlace)
            {
                Debug.Log("Cannot place Spike here");
            }
            else
            {
                Debug.Log("Ran out of Spikes");
            }
        }
            
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "NoBarrier")
        {
            CanPlace = false;
        }

    }

    void OnTriggerExit2D(Collider2D other2)
    {
        if (other2.gameObject.tag == "NoBarrier")
        {
            CanPlace = true;
        }
    }
    
}
