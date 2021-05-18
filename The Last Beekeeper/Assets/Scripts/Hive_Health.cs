using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hive_Health : MonoBehaviour
{
    public Image healthBar_UI;
    public GameObject player;
    public Text healthBar_text;
    public int maxHealth, currentHealth;
    public float hittimer, timebetweenhits;
    public bool cantakedamage;
    public Color initcolor, endcolor;
    public EndConditionManager ecm;

    // Start is called before the first frame update
    void Start()
    {
        if (healthBar_UI != null)
        {
            initcolor = healthBar_UI.color;
        }
        currentHealth = maxHealth;
        cantakedamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Hive Healthbar UI
        float healthbarwidth = Mathf.Lerp(0, 1, ((float)currentHealth / (float)maxHealth));

        Color newcolor = Color.Lerp(endcolor, initcolor, ((float)currentHealth / (float)maxHealth));

        if (healthBar_UI != null)
        {
            healthBar_UI.rectTransform.localScale = new Vector3(healthbarwidth, 1, 1);
            healthBar_UI.color = newcolor;
        }

        if (healthBar_text != null)
        {
            healthBar_text.text = "Hive: " + currentHealth + " / " + maxHealth;
        }


        //Everything else, please send more help
        if (!cantakedamage)
        {
            if (hittimer < timebetweenhits)
            {
                hittimer += Time.deltaTime;
            }
            else if (hittimer >= timebetweenhits)
            {
                hittimer = 0;
                cantakedamage = true;
            }
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            ecm.triggerLoss("letting the Hive die.");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && cantakedamage)
        {
            currentHealth--;
            cantakedamage = false;
        }
    }

    
}
