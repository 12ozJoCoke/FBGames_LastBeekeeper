using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllSpawners_Manager : MonoBehaviour
{
    public GameObject player;
    public List<Enemy_Health> allEnemies;
    public List<Enemy_Spawner> allSpawners;
    public int maxEnemiesInScene, waveNumber, enemiesPerWave, spawnedEnemiesInWave;
    public Text waveCounter_UI;
    public Color defaultTextColor, waveReadyTextColor;
    public bool canSpawn, proceedWave, completedWave;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        waveNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (allEnemies.Count != 0)
        {
            if (allEnemies.Count < maxEnemiesInScene && spawnedEnemiesInWave < enemiesPerWave)
            {
                canSpawn = true;
            }

            foreach (Enemy_Health enemy in allEnemies)
            {
                if (enemy.dead)
                {
                    allEnemies.Remove(enemy);
                    enemy.Kill();
                }
            }
        }

        if (spawnedEnemiesInWave >= enemiesPerWave)
        {
            completedWave = false;
            canSpawn = false;
        }

        if (spawnedEnemiesInWave == enemiesPerWave && allEnemies.Count == 0 && proceedWave)
        {
            spawnedEnemiesInWave = 0;
            waveNumber++;
            canSpawn = true;
            proceedWave = false;
            waveCounter_UI.color = defaultTextColor;
        }else if (spawnedEnemiesInWave == enemiesPerWave && allEnemies.Count == 0 && !proceedWave)
        {
            if (!completedWave)
            {
                completedWave = true;
            }
            waveCounter_UI.color = waveReadyTextColor;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            proceedWave = true;
        }

        waveCounter_UI.text = "Wave " + waveNumber;
    }

    public void AddEnemy(Enemy_Health enemy)
    {
        if ((allEnemies.Count + 1) <= maxEnemiesInScene && canSpawn)
        {
            enemy.name = "Enemy" + (allEnemies.Count + 1);
            enemy.player = player.GetComponent<Player_attacking>();
            enemy.SpawnHealthBar(enemy.name);
            allEnemies.Add(enemy);
            spawnedEnemiesInWave++;
        }else if ((allEnemies.Count + 1) > maxEnemiesInScene || !canSpawn)
        {
            Debug.Log("Maxed enemies");
            Destroy(enemy.gameObject);
            canSpawn = false;
        }
    }
}
