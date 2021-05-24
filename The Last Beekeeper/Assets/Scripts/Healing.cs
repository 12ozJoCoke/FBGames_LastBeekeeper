using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    public int Amount, MaxAmount, StartAmount, healing;
    public bool canHeal, canBuy;
    public float delay, timer;
    public Text text;

    Player_health HP;
    Player_PointsManager ppm;
    void Start()
    {
        Amount = StartAmount;
        canHeal = true;

        HP = GetComponent<Player_health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Amount >= MaxAmount)
        {
            Amount = MaxAmount;
                canBuy = false;
        }
        else if(Amount <= MaxAmount)
        {
            canBuy = true;
        }
        text.text = Amount + "/" + MaxAmount + " :Heals\r\n";
        if (Input.GetKeyDown(KeyCode.H))
        {
            if(Amount > 0 && canHeal && HP.health < HP.maxhealth)
            {
                HP.health += healing;
                Amount--;
                canHeal = false;
            }
        }

        if (!canHeal)
        {
            if(timer < delay)
            {
                timer += Time.deltaTime;
            }
            else if(timer >= delay)
            {
                timer = 0;
                canHeal = true;
            }
        }

    }

    public void BuyHealth(int pointsspend)
    {
        if (ppm.currentPoints >= pointsspend)
        {
            ppm.RemovePoints(pointsspend);
            Amount++;
        }

    }
}
