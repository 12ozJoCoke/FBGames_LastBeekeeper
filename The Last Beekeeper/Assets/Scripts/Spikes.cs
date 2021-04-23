using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damageInt, timer;
    public int damage;
    public bool CanDoDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        CanDoDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= damageInt)
        {
            CanDoDamage = true;
            timer += Time.deltaTime;
        }
        else if(timer >= damageInt)
        {
            timer = 0;
            CanDoDamage = false;
        }
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.gameObject.tag == "Enemy")
        {
           
            if (CanDoDamage)
            {
                enemy.gameObject.GetComponent<Enemy_Health>().TakeDamage(damage, "Melee", transform.position);
            }

        }
    }

}
