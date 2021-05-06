using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public GameObject player, target, hive;
    public PauseManager pause_m;
    public float movementSpeed, timeBetweenChecks, checkTimer;
    Rigidbody2D rb2;
    // Start is called before the first frame update
    void Start()
    {
        pause_m = GameObject.Find("Pause Manager").GetComponent<PauseManager>();
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause_m.IsPaused)
        {
            if (checkTimer < timeBetweenChecks)
            {
                checkTimer += Time.deltaTime;
            }
            else if (checkTimer >= timeBetweenChecks)
            {
                checkTimer = 0;
                //CheckWhichTarget();
            }

            Vector3 mov = Vector3.zero;
            if (target != null)
            {
                Vector3 mousePos = target.transform.position;
                mousePos.z = transform.position.z;
                Vector3 mosPos = mousePos;
                mosPos.x = mousePos.x - transform.position.x;
                mosPos.y = mousePos.y - transform.position.y;
                float angle = Mathf.Atan2(mosPos.y, mosPos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

                mov = transform.up * movementSpeed;
            }
            rb2.velocity = mov;
        }
    }

    void CheckWhichTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3 hivepos = new Vector3(hive.transform.position.x, hive.transform.position.y, 0);
        Vector3 playpos = new Vector3(player.transform.position.x, player.transform.position.y, 0);

        float hivedist = Vector3.Distance(pos, hivepos);
        float playdist = Vector3.Distance(pos, playpos);

        if (hivedist < playdist)
        {
            target = hive;
        }else if (playdist < hivedist)
        {
            target = player;
        }
    }
}
