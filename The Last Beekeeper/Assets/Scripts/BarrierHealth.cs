using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierHealth : MonoBehaviour
{
    public float nodamage, timeyboi;
    public int BarrierHp, maxHP;
    public bool youstilltakeadamage;

    
    
    void Start()
    {
        BarrierHp = maxHP;
        youstilltakeadamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (!youstilltakeadamage)
        {
            if (timeyboi < nodamage)
            {
                timeyboi += Time.deltaTime;
                youstilltakeadamage = false;
            }
            else if(timeyboi >= nodamage)
            {
                timeyboi = 0;
                youstilltakeadamage = true;
            }
        }
        
       if(BarrierHp == 0)
        {
            Destroy(gameObject);
                
            }
    }
    
   
    private void OnCollisionStay2D(Collision2D other)
    {
       if(other.gameObject.tag == "Enemy" && youstilltakeadamage)
        {
            BarrierHp--;
            youstilltakeadamage = false;
        }
    }

    public void Spawnadabar()
    {
        
    }
}
