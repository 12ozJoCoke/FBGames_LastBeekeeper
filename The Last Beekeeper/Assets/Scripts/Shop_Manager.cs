using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Manager : MonoBehaviour
{
    public int PointsForShootingTurret, PointsForMeleeTurret, PointsForBarrier, PointsForSpikes;
    public Canvas ShopMenu;
    AllSpawners_Manager asm;
    Player_TurretConstruction ptc;
    Barier_making bm;
    // Start is called before the first frame update
    void Start()
    {
        asm = GameObject.Find("Spawner_Axis").GetComponent<AllSpawners_Manager>();
        ptc = GameObject.Find("Soldier").GetComponent<Player_TurretConstruction>();
        bm = GameObject.Find("Soldier").GetComponent<Barier_making>();
    }

    // Update is called once per frame
    void Update()
    {
        if (asm.completedWave)
        {
            ShopMenu.gameObject.SetActive(true);
        }else
        {
            ShopMenu.gameObject.SetActive(false);
        }
    }

    public void BuyShooter()
    {
        ptc.BuyShooter(PointsForShootingTurret);
    }

    public void BuyBrawler()
    {
        ptc.BuyBrawler(PointsForMeleeTurret);
    }

    public void BuyBarrier()
    {
        bm.BuyBarrier(PointsForBarrier);
    }

    public void BuySpike()
    {
        bm.BuySpike(PointsForSpikes);
    }
}
