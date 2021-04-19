using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles_ObjectOptimization : MonoBehaviour
{
    float timeAlive;
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.particleCount == 0 && timeAlive > 0.5f)
        {
            Destroy(gameObject);
        }
        timeAlive += Time.deltaTime;
    }
}
