using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonManager_Grabber : MonoBehaviour
{
    public Enemy_PathfindingPylon[] pylons;
    // Start is called before the first frame update
    void Start()
    {
        pylons = GetComponentsInChildren<Enemy_PathfindingPylon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
