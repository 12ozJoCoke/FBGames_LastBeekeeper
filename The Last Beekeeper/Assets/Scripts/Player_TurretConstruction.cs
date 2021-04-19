using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_TurretConstruction : MonoBehaviour
{
    public GameObject shootingTurretPrefab, meleeTurretPrefab;
    public int shootingTurretsOnHand, meleeTurretsOnHand;
    AllSpawners_Manager asm;
    Player_PointsManager ppm;
    public Text turretsInventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        asm = GameObject.Find("Spawner_Axis").GetComponent<AllSpawners_Manager>();
        ppm = GetComponent<Player_PointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (meleeTurretsOnHand >= 1)
                {
                    meleeTurretsOnHand--;
                    Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPos.z = 0;

                    GameObject newMeleeTurret = GameObject.Instantiate(meleeTurretPrefab, spawnPos, Quaternion.identity);
                    newMeleeTurret.GetComponent<Turret_Rotating>().asm = asm;
                }
            }
            else if (shootingTurretsOnHand >= 1)
            {
                shootingTurretsOnHand--;
                Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPos.z = 0;

                GameObject newShootingTurret = GameObject.Instantiate(shootingTurretPrefab, spawnPos, Quaternion.identity);
                newShootingTurret.GetComponent<Turret_Rotating>().asm = asm;
            }
        }

        turretsInventoryUI.text = shootingTurretsOnHand + " Shooting Turrets\r\n" + meleeTurretsOnHand + " Melee Turrets";
    }

    public void BuyBrawler(int pointsspend)
    {
        if (ppm.currentPoints >= pointsspend)
        {
            ppm.RemovePoints(pointsspend);
            meleeTurretsOnHand++;
        }
    }
    public void BuyShooter(int pointsspend)
    {
        if (ppm.currentPoints >= pointsspend)
        {
            ppm.RemovePoints(pointsspend);
            shootingTurretsOnHand++;
        }
    }
}
