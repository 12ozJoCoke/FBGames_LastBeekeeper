using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barier_making : MonoBehaviour
{
    public int BarrierAmount;
    public GameObject BarrierPre;
    public int SpikeAmount;
    public GameObject MeleeSpike, RangeSpike, AllSpike;
    private GameObject Player;
    public bool CanPlace;
    public bool MSpike, RSpike, ASpike;
    Player_PointsManager ppm;
    public Text text;
    void Start()
    {
        ppm = GetComponent<Player_PointsManager>();
        Player = gameObject;
        CanPlace = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (BarrierAmount <= 0)
        {
            BarrierAmount = 0;
        }
        text.text = BarrierAmount + " :Barriers\r\n" + SpikeAmount + " :Spikes";
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (BarrierAmount > 0 && !!CanPlace)
            {
                Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPos.z = 0;

                Instantiate(BarrierPre, spawnPos, Quaternion.identity);

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
        if (SpikeAmount <= 0)
        {
            SpikeAmount = 0;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            MSpike = true;
            RSpike = false;
            ASpike = false;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            MSpike = false;
            RSpike = true;
            ASpike = false;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            MSpike = false;
            RSpike = false;
            ASpike = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (SpikeAmount > 0 && CanPlace)
            {
                if (MSpike)
                {
                    Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPos.z = 0;

                    Instantiate(MeleeSpike, spawnPos, Quaternion.identity);
                }
                else if (RSpike)
                {
                    Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPos.z = 0;

                    Instantiate(RangeSpike, spawnPos, Quaternion.identity);
                }
                else if (AllSpike)
                {
                    Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPos.z = 0;

                    Instantiate(AllSpike, spawnPos, Quaternion.identity);
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
