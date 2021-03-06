using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject player, hive;
    public GameObject enemyPrefab;
    public float timeBetweenSpawns;
    public AllSpawners_Manager manager;
    public PylonManager_Grabber grabber;
    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(timeBetweenSpawns * 0.5f, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer < timeBetweenSpawns)
        {
            spawnTimer += Time.deltaTime;
        }else if (spawnTimer >= timeBetweenSpawns)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float randomProperty = Random.Range(1,100);
        GameObject newEnemy = GameObject.Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy_Movement>().player = player;
        newEnemy.GetComponent<Enemy_Movement>().hive = hive;
        newEnemy.GetComponent<Enemy_Movement>().target = newEnemy.GetComponent<Enemy_Movement>().player;
        newEnemy.GetComponent<Enemy_PathfindingManager>().pylons = grabber.pylons;
        newEnemy.GetComponent<Enemy_PathfindingManager>().specialpylon = hive.GetComponent<Enemy_PathfindingPylon>();

        if (randomProperty <= 50)
        {
            Enemy_Health newenemy = newEnemy.GetComponent<Enemy_Health>();
            newenemy.canTakeBulletDamage = true;
            newenemy.GetComponent<SpriteRenderer>().sprite = newenemy.BooletDamage;
        }
        else if (randomProperty > 50)
        {
            Enemy_Health newenemy = newEnemy.GetComponent<Enemy_Health>();
            newenemy.canTakeBulletDamage = false;
            newenemy.GetComponent<SpriteRenderer>().sprite = newenemy.MeleeDamage;
        }

        manager.AddEnemy(newEnemy.GetComponent<Enemy_Health>());
    }
}
