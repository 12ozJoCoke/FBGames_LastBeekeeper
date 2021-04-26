using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damageInt, timer;
    public int damage;
    public bool CanDoDamage;
    public bool meleedmg, rangedmg;
    public int durabillity, MaxDura, usage;

    // Start is called before the first frame update
    void Start()
    {
        durabillity = MaxDura;
        CanDoDamage = true;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanDoDamage)
        {
            if (timer <= damageInt)
            {
                CanDoDamage = true;
                timer += Time.deltaTime;
            }
            else if (timer >= damageInt)
            {
                timer = 0;
                CanDoDamage = false;
            }
        }

        if (durabillity <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.gameObject.tag == "Enemy")
        {
           
            if (CanDoDamage)
            {
                if(meleedmg && !rangedmg)
                {
                    enemy.gameObject.GetComponent<Enemy_Health>().TakeDamage(damage, "Melee", transform.position);
                    CanDoDamage = false;
                    durabillity --;

                }
                else if(!meleedmg && rangedmg)
                {
                    enemy.gameObject.GetComponent<Enemy_Health>().TakeDamage(damage, "Bullet", transform.position);
                    CanDoDamage = false;
                    durabillity --;
                }
                else if(meleedmg && rangedmg)
                {
                    enemy.gameObject.GetComponent<Enemy_Health>().TakeDamage(damage, "Bullet", transform.position);
                    enemy.gameObject.GetComponent<Enemy_Health>().TakeDamage(damage, "Melee", transform.position);
                    CanDoDamage = false;
                    durabillity --;
                }
                
            }

        }

       
    }

}
