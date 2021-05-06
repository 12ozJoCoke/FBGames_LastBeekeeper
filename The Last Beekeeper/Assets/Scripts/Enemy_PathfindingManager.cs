using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PathfindingManager : MonoBehaviour
{
    public Enemy_Movement em;
    public Enemy_PathfindingPylon[] pylons;
    public Enemy_PathfindingPylon specialpylon;
    public float TimeBetweenChecks, TimeCheckTimer, DistToAutoCheck;
    public int IgnoreThisPylon;
    public int pylonref;

    // Start is called before the first frame update
    void Start()
    {
        IgnoreThisPylon = -1;
        em = GetComponent<Enemy_Movement>();
        TimeCheckTimer = TimeBetweenChecks;
    }

    // Update is called once per frame
    void Update()
    {

        if (TimeCheckTimer < TimeBetweenChecks)
        {
            TimeCheckTimer += Time.deltaTime;
        }else if (TimeCheckTimer >= TimeBetweenChecks)
        {
            //pylonref = -1;

            TimeCheckTimer = 0;

            Vector3 pos = transform.position;
            pos.z = 0;
            Vector3 closestpos = em.target.transform.position;
            if (IgnoreThisPylon >= 0)
            {
                closestpos = em.player.transform.position;
            }

            closestpos.z = 0;

            if (pylons[pylonref] != specialpylon)
            {
                for (int i = 0; i < pylons.Length; i++)
                {
                    if (i != IgnoreThisPylon)
                    {
                        Vector3 pylonpos = pylons[i].transform.position;
                        pylonpos.z = 0;

                        float distbetweenclosest = Vector3.Distance(pos, closestpos);
                        float distbetweenpylon = Vector3.Distance(pos, pylonpos);

                        if (distbetweenpylon < distbetweenclosest)
                        {
                            closestpos = pylonpos;
                            pylonref = i;
                        }
                    }
                }
            }

            if (pylonref >= 0)
            {
                em.target = pylons[pylonref].gameObject;
            }
        }

        Vector3 posi = transform.position;
        posi.z = 0;
        Vector3 closestposi = em.target.transform.position;
        closestposi.z = 0;

        if (Vector3.Distance(posi, closestposi) <= DistToAutoCheck)
        {
            if (pylons[pylonref].next != null)
            {
                em.target = pylons[pylonref].next.gameObject;
                pylonref = Array.IndexOf(pylons, pylons[pylonref].next);
            }
        }
    }


}
