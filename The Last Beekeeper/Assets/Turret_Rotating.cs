using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Rotating : MonoBehaviour
{
    public AllSpawners_Manager asm;
    public Vector3 closestEnemyPos;
    public Turret_Shooting ts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemyPos = new Vector3(1000,1000,0);

        if (asm.allEnemies.Count >= 0)
        {
            foreach (Enemy_Health enemy in asm.allEnemies)
            {
                Vector3 turretPos = new Vector3(transform.position.x, transform.position.y, 0);
                Vector3 enemyPos = new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0);

                float distbetweencurclosest = Vector3.Distance(turretPos, closestEnemyPos);
                float distbetweencheckedenemy = Vector3.Distance(turretPos, enemyPos);

                if (distbetweencheckedenemy < distbetweencurclosest)
                {
                    closestEnemyPos = enemyPos;

                    if (enemy.canTakeBulletDamage)
                    {
                        ts.closestEnemyType = Turret_Shooting.attackStates.Shooting;
                    }else
                    {
                        ts.closestEnemyType = Turret_Shooting.attackStates.Melee;
                    }
                }
            }

            Vector3 mousePos = closestEnemyPos;
            mousePos.x = mousePos.x - transform.position.x;
            mousePos.y = mousePos.y - transform.position.y;
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        }
        else if (asm.allEnemies.Count == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
