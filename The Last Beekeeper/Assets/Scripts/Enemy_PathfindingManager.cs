using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PathfindingManager : MonoBehaviour
{
    public Enemy_Movement em;
    public Enemy_PathfindingPylon[] pylons;
    public float TimeBetweenChecks, TimeCheckTimer;

    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<Enemy_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeCheckTimer < TimeBetweenChecks)
        {
            TimeCheckTimer += Time.deltaTime;
        }else if (TimeCheckTimer >= TimeBetweenChecks)
        {
            TimeCheckTimer = 0;

            Vector3 pos = transform.position;
            pos.z = 0;
            Vector3 closestpos = em.player.transform.position;
            int pylonref = -1;
            closestpos.z = 0;

            for (int i = 0; i < pylons.Length; i++)
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

            if (pylonref >= 0)
            {
                em.target = pylons[pylonref].gameObject;
            }
        }
    }
}
