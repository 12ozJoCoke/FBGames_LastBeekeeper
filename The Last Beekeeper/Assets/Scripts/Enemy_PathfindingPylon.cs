using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PathfindingPylon : MonoBehaviour
{
    public Enemy_PathfindingPylon next, next2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallNext(Enemy_Movement enemy)
    {
        if (!next2)
        {
            enemy.target = next.gameObject;
        }else
        {
            float f = Random.Range(0, 100);
            if (f < 50)
            {
                enemy.target = next.gameObject;
            }else if (f > 50)
            {
                enemy.target = next2.gameObject;
            }
        }
    }
}
