using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_attacking : MonoBehaviour
{
    public enum attackStates
    {
        Melee,
        Shooting
    };
    attackStates attackingMode;
    float mouseScrollCounter;
    float scrollSensitivity = 0.1f;
    public Image uiIndication_Melee, uiIndication_Shooting;
    public GameObject bulletPrefab, meleeParticlesPrefab, meleeAttackPrefab;
    Player_PointsManager ppm;
    public PauseManager pause_m;

    public int meleeDamage, bulletDamage, pointsPerEnemyMeleeHit, pointsPerEnemyBulletHit;

    public float gun_FiringRate_RPM, gun_FiringTimer, melee_PunchingRate, bulletLife, bulletForce, bullet_spawn_forwardoffset, meleeRange, bullet_Diversion, max_Bullet_SpreadForce;
    float gun_FiringRate_SPR, melee_PunchingRate_SPR;
    public AudioClip shootingSFX, meleeSFX;

    public bool canAutoSwitch;

    // Start is called before the first frame update
    void Start()
    {
        pause_m = GameObject.Find("Pause Manager").GetComponent<PauseManager>();

        attackingMode = attackStates.Shooting;

        gun_FiringRate_SPR = gun_FiringRate_RPM / 60;
        gun_FiringRate_SPR = 1 / gun_FiringRate_SPR;

        melee_PunchingRate_SPR = melee_PunchingRate / 60;
        melee_PunchingRate_SPR = 1 / melee_PunchingRate_SPR;

        ppm = GetComponent<Player_PointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause_m.IsPaused)
        {
            //Switching State with Input
            if (Input.GetAxis("Mouse ScrollWheel") != 0 || Input.GetKeyDown(KeyCode.Q))
            {
                if (!Input.GetKeyDown(KeyCode.Q))
                {
                    mouseScrollCounter += Input.GetAxis("Mouse ScrollWheel");
                }
                else
                {
                    mouseScrollCounter = scrollSensitivity;
                }

                if (Mathf.Abs(mouseScrollCounter) >= scrollSensitivity)
                {
                    mouseScrollCounter = 0;
                    if (attackingMode == attackStates.Melee)
                    {
                        attackingMode = attackStates.Shooting;
                    }
                    else if (attackingMode == attackStates.Shooting)
                    {
                        attackingMode = attackStates.Melee;
                    }
                }
            }

            //Doing Stuff Based On State
            if (attackingMode == attackStates.Melee)
            {
                //Setting UI Inditication
                uiIndication_Melee.gameObject.SetActive(true);
                uiIndication_Shooting.gameObject.SetActive(false);

                if (Input.GetButtonDown("Fire1"))
                {
                    gun_FiringTimer = melee_PunchingRate_SPR;
                }
                if (Input.GetButton("Fire1"))
                {
                    if (gun_FiringTimer >= melee_PunchingRate_SPR)
                    {
                        gun_FiringTimer = 0;
                        CreateSFX(meleeSFX);
                        ShootBullet(meleeParticlesPrefab, meleeRange, 0, bulletLife);
                        ShootBullet(meleeAttackPrefab, meleeRange, 0, bulletLife);
                        Attack(meleeRange);
                    }
                    else
                    {
                        gun_FiringTimer += Time.deltaTime;
                    }
                }
            }
            else if (attackingMode == attackStates.Shooting)
            {
                //Setting UI Inditication
                uiIndication_Melee.gameObject.SetActive(false);
                uiIndication_Shooting.gameObject.SetActive(true);

                if (Input.GetButtonDown("Fire1"))
                {
                    gun_FiringTimer = gun_FiringRate_SPR;
                }
                if (Input.GetButton("Fire1"))
                {
                    if (gun_FiringTimer >= gun_FiringRate_SPR)
                    {
                        gun_FiringTimer = 0;
                        CreateSFX(shootingSFX);
                        ShootBullet(bulletPrefab, bullet_spawn_forwardoffset, bulletForce, bulletLife);
                    }
                    else
                    {
                        gun_FiringTimer += Time.deltaTime;
                    }
                }
            }
        }
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

    void ShootBullet(GameObject prefabi, float offset, float force, float life)
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
            newbullet.GetComponent<BulletScript>().ppm = ppm;
            newbullet.GetComponent<BulletScript>().pointsPerEnemyBulletHit = pointsPerEnemyBulletHit;
        }

        Destroy(newbullet, life);
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
                    ppm.AddPoints(pointsPerEnemyMeleeHit);
                }
            }
        }
    }

    public void AutoSwitch(string enemysource)
    {
        if (canAutoSwitch)
        {
            if (enemysource == "Melee")
            {
                attackingMode = attackStates.Melee;
            }else if (enemysource == "Bullet")
            {
                attackingMode = attackStates.Shooting;
            }
        }
    }
}
