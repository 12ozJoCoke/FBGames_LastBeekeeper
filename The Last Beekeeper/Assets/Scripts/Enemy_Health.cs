using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public GameObject healthbarPrefab, goopPrefab;
    public Player_attacking player;
    public float healthbar_offset;
    public int maxHealth, currentHealth;
    public bool dead, canTakeBulletDamage;
    GameObject used_healthbar;
    // Start is called before the first frame update
    void Start()
    {
        if (used_healthbar == null)
        {
            SpawnHealthBar(gameObject.name);
        }

        dead = false;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        used_healthbar.transform.position = transform.position + (Vector3.up * healthbar_offset);
        float percentage = (float)currentHealth / (float)maxHealth;
        used_healthbar.transform.localScale = new Vector3(Mathf.Lerp(0, 2, percentage), 0.5f, 1);

        if (currentHealth <= 0)
        {
            dead = true;
        }
    }
    
    public void TakeDamage(int damage, string source, Vector3 hitpos)
    {
        Enemy_Movement thisenemiesmovement = gameObject.GetComponent<Enemy_Movement>();
        if (canTakeBulletDamage && source == "Bullet")
        {
            Debug.Log(name + " took " + damage + " damage from a " + source + " attack");
            currentHealth -= damage;
        }
        else if (!canTakeBulletDamage && source == "Melee")
        {
            Debug.Log(name + " took " + damage + " damage from a " + source + " attack");
            currentHealth -= damage;
        }
        thisenemiesmovement.target = thisenemiesmovement.player;
        GameObject newgoop = GameObject.Instantiate(goopPrefab, hitpos, Quaternion.identity);
    }

    public void SpawnHealthBar(string name)
    {
        GameObject healthbar = GameObject.Instantiate(healthbarPrefab, transform.position, Quaternion.identity);
        healthbar.name = gameObject.name + "Healthbar";
        used_healthbar = healthbar;
    }
    public void Kill()
    {
        Destroy(used_healthbar);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (canTakeBulletDamage)
        {
            player.AutoSwitch("Bullet");
        }else
        {
            player.AutoSwitch("Melee");
        }
    }
}
