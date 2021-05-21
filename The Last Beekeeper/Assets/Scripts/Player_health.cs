using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_health : MonoBehaviour
{
    public Image healthBar_UI;
    public Text healthBar_text;

    public Color initcolor, endcolor;

    public int health, maxhealth;
    public float hittimer, timebetweenhits, healthbar_offset;
    public GameObject healthbarPrefab;
    bool cantakedamage, touchingenemy;

    public Animator camerashake;

    public EndConditionManager ecm;
    // Start is called before the first frame update
    void Start()
    {
        if (healthBar_UI != null)
        {
            initcolor = healthBar_UI.color;
        }

        health = maxhealth;
        cantakedamage = true;
        hittimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        camerashake.SetBool("shake", !cantakedamage);

        //Player Heathbar UI
        float healthbarwidth = Mathf.Lerp(0, 1, ((float)health / (float)maxhealth));

        Color newcolor = Color.Lerp(endcolor, initcolor, ((float)health / (float)maxhealth));

        if (healthBar_UI != null)
        {
            healthBar_UI.rectTransform.localScale = new Vector3(healthbarwidth, 1, 1);
            healthBar_UI.color = newcolor;
        }

        if (healthBar_text != null)
        {
            healthBar_text.text = "Player: " + health + " / " + maxhealth;
        }

        if (health <= 0)
        {
            health = 0;
            ecm.triggerLoss("dying.");
        }

        //Everything else please send help
        if (!cantakedamage)
        {
            if (hittimer < timebetweenhits)
            {
                hittimer += Time.deltaTime;
            }else if (hittimer >= timebetweenhits)
            {
                hittimer = 0;
                cantakedamage = true;
            }
        }

        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && cantakedamage)
        {
            health--;
            cantakedamage = false;
        }

        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "AllSpike" && cantakedamage)
        {

            health = health - 5;
            cantakedamage = false;
        }
    }

    
}
