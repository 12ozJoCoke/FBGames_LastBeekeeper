using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barier_making : MonoBehaviour
{
    public int BarrierAmount, MaxAmount;
    public GameObject BarrierPre;
    public int SpikeAmount, MaxSpikeAmount;
    public GameObject MeleeSpike, RangeSpike, AllSpike;
    private GameObject Player;
    public bool CanPlace;
    public bool MSpike, RSpike, ASpike;
    Player_PointsManager ppm;
    public Text text;
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
        text.text = BarrierAmount + "/" + MaxAmount + " :Barriers" + " " + SpikeAmount + "/" + MaxSpikeAmount + " :Spikes";
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

        if (Input.GetKeyDown(KeyCode.I))
        {
            MSpike = true;
            RSpike = false;
            ASpike = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            MSpike = false;
            RSpike = true;
            ASpike = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            MSpike = false;
            RSpike = false;
            ASpike = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (SpikeAmount > 0 && !!CanPlace)
            {
                if (MSpike)
                {
                    Instantiate(MeleeSpike, transform.position, Quaternion.identity);
                }
                else if (RSpike)
                {
                    Instantiate(RangeSpike, transform.position, Quaternion.identity);
                }
                else if (AllSpike)
                {
                    Instantiate(AllSpike, transform.position, Quaternion.identity);
                }

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

    void OnCollisionStay2D(Collision2D pbt)
    {
        if (pbt.gameObject.tag == "NoBarrier")
        {
            CanPlace = false;
        }
    }

    void OnCollisionExit2D(Collision2D pbt2)
    {
        if (pbt2.gameObject.tag == "NoBarrier")
        {
            CanPlace = true;
        }
        
    }

    public void BuyBarrier(int pointsspend)
    {
        if (ppm.currentPoints >= pointsspend)
        {
            ppm.RemovePoints(pointsspend);
            BarrierAmount++;
        }
    }
    public void BuySpike(int pointsspend)
    {
        if (ppm.currentPoints >= pointsspend)
        {
            ppm.RemovePoints(pointsspend);
            SpikeAmount++;
        }
    }

}
