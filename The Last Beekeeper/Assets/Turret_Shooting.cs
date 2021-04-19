using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Shooting : MonoBehaviour
{
    public Turret_Rotating tr;
    public float distanceToShootFrom;
    Vector3 closestEnemyPos;

    //Actual attacking stuff most of which i just copied from the player scripts because i could just not be arsed
    public enum attackStates
    {
        Melee,
        Shooting
    };
    public attackStates attackingMode;
    public attackStates closestEnemyType;
    public int meleeDamage, bulletDamage;
    public GameObject bulletPrefab, meleeParticlesPrefab, meleeAttackPrefab;
    bool shootBool;
    public float gun_FiringRate_RPM, gun_FiringTimer, melee_PunchingRate, bulletLife, bulletForce, bullet_spawn_forwardoffset, meleeRange, bullet_Diversion, max_Bullet_SpreadForce;
    float gun_FiringRate_SPR, melee_PunchingRate_SPR;
    public AudioClip shootingSFX, meleeSFX;

    // Start is called before the first frame update
    void Start()
    {
        gun_FiringRate_SPR = gun_FiringRate_RPM / 60;
        gun_FiringRate_SPR = 1 / gun_FiringRate_SPR;

        melee_PunchingRate_SPR = melee_PunchingRate / 60;
        melee_PunchingRate_SPR = 1 / melee_PunchingRate_SPR;
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemyPos = tr.closestEnemyPos;
        closestEnemyPos.z = 0;

        Vector3 turretPos = new Vector3(transform.position.x, transform.position.y, 0);

        if (Vector3.Distance(turretPos, closestEnemyPos) <= distanceToShootFrom && (closestEnemyType == attackingMode))
        {
            shootBool = true;
        }else
        {
            shootBool = false;
        }

        if (shootBool)
        {
            if (attackingMode == attackStates.Melee)
            {
                if (gun_FiringTimer >= melee_PunchingRate_SPR)
                {
                    gun_FiringTimer = 0;
                    CreateSFX(meleeSFX);
                    Shoot(meleeParticlesPrefab, meleeRange, 0, bulletLife);
                    Shoot(meleeAttackPrefab, meleeRange, 0, bulletLife);
                    Attack(meleeRange);
                }
                else
                {
                    gun_FiringTimer += Time.deltaTime;
                }
            }
            else if (attackingMode == attackStates.Shooting)
            {
                if (gun_FiringTimer >= gun_FiringRate_SPR)
                {
                    gun_FiringTimer = 0;
                    CreateSFX(shootingSFX);
                    Shoot(bulletPrefab, bullet_spawn_forwardoffset, bulletForce, bulletLife);
                }
                else
                {
                    gun_FiringTimer += Time.deltaTime;
                }
            }
        }
    }

    void Shoot(GameObject prefabi, float offset, float force, float life)
    {
        GameObject newbullet = GameObject.Instantiate(prefabi, transform.position + (transform.up * offset), transform.rotation);
        float sideSpread = Random.Range(-bullet_Diversion, bullet_Diversion);
        sideSpread *= max_Bullet_SpreadForce;
        if (force != 0)
        {
            newbullet.GetComponent<Rigidbody2D>().AddForce(newbullet.transform.up * force);
            newbullet.GetComponent<Rigidbody2D>().AddForce(newbullet.transform.right * sideSpread);
        }

        if (newbullet.GetComponent<BulletScript>())
        {
            newbullet.GetComponent<BulletScript>().damageOutput = bulletDamage;
        }

        Destroy(newbullet, life);
    }

    void CreateSFX(AudioClip sfx)
    {
        AudioSource tempas = new GameObject().AddComponent<AudioSource>();
        tempas.transform.position = transform.position;
        tempas.clip = sfx;
        float lifetime = sfx.length;
        tempas.Play();
        Destroy(tempas.gameObject, lifetime);
    }

    void Attack(float range)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.up * bullet_spawn_forwardoffset), transform.up);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Enemy")
            {
                Vector3 hitpos = new Vector3(hit.point.x, hit.point.y, 0);
                Vector3 playpos = new Vector3(transform.position.x, transform.position.y, 0);
                if (Vector3.Distance(hitpos, playpos) <= range)
                {
                    GameObject enemyobject = hit.collider.gameObject;
                    enemyobject.GetComponent<Enemy_Health>().TakeDamage(meleeDamage, "Melee", hitpos);
                }
            }
        }
    }
}
