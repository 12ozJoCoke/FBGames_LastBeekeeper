using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Manager : MonoBehaviour
{
    public int PointsForShootingTurret, PointsForMeleeTurret;
    public Canvas ShopMenu;
    AllSpawners_Manager asm;
    Player_TurretConstruction ptc;

    // Start is called before the first frame update
    void Start()
    {
        asm = GameObject.Find("Spawner_Axis").GetComponent<AllSpawners_Manager>();
        ptc = GameObject.Find("Soldier").GetComponent<Player_TurretConstruction>();
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
}
