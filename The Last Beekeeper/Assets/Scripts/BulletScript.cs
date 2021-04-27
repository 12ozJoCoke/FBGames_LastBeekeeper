using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damageOutput, pointsPerEnemyBulletHit;
    public Player_PointsManager ppm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (ppm && collision.gameObject.GetComponent<Enemy_Health>())
            {
                if (collision.gameObject.GetComponent<Enemy_Health>().canTakeBulletDamage)
                {
                    ppm.AddPoints(pointsPerEnemyBulletHit);
                }
            }

            collision.gameObject.GetComponent<Enemy_Health>().TakeDamage(damageOutput, "Bullet", transform.position);
            Destroy(gameObject);
        }
    }
}
