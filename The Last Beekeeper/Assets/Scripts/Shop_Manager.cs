using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Manager : MonoBehaviour
{
    public int PointsForShootingTurret, PointsForMeleeTurret, PointsForBarrier, PointsForSpikes, PointsForHeals, PointsForWalkSpeedBoost, speedBoostsAvailable;
    public Canvas ShopMenu;
    AllSpawners_Manager asm;
    Player_TurretConstruction ptc;
    Barier_making bm;
    player_running Playermove;
    Player_PointsManager ppm;
    Healing h;
    // Start is called before the first frame update
    void Start()
    {
        speedBoostsAvailable = 5;
        ppm = GameObject.Find("Soldier").GetComponent<Player_PointsManager>();
        asm = GameObject.Find("Spawner_Axis").GetComponent<AllSpawners_Manager>();
        ptc = GameObject.Find("Soldier").GetComponent<Player_TurretConstruction>();
        bm = GameObject.Find("Soldier").GetComponent<Barier_making>();
        Playermove = GameObject.Find("Soldier").GetComponent<player_running>();
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

    public void BuyHeals()
    {
        h.BuyHealth(PointsForHeals);
    }
    public void BuyWalkSpeedBoost()
    {
        if (ppm.currentPoints >= PointsForWalkSpeedBoost && speedBoostsAvailable >= 1)
        {
            speedBoostsAvailable--;
            ppm.currentPoints -= PointsForWalkSpeedBoost;
            Playermove.RunWalkBoost();
        }
    }
}
