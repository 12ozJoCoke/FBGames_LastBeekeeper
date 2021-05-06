using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySettingForLevel : MonoBehaviour
{
    public List<int> PlayerHealth_Difficulties, HiveHealth_Difficulties, EnemyInSceneCap_Difficulties, EnemyWaveCap_Difficulties;
    public DifficultySelector diffsel;
    
    int chosenDifficulty;
    bool hasProcessedSceneAddons;

    // Start is called before the first frame update
    void Start()
    {
        diffsel = GameObject.Find("DifficultySelector").GetComponent<DifficultySelector>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(diffsel.boundStartKey))
        //{
        //    LoadLevel("LevelMakin");
        //}

        if (!hasProcessedSceneAddons)
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "LevelMakin")
            {
                hasProcessedSceneAddons = true;
                AssignStuff();
            }
        }
    }

    public void LoadLevel(string LevelSceneName)
    {
        if (diffsel.difficulty == (DifficultySelector.difficulties)1)
        {
            chosenDifficulty = 1;
        }else if (diffsel.difficulty == (DifficultySelector.difficulties)2)
        {
            chosenDifficulty = 2;
        }
        else if (diffsel.difficulty == (DifficultySelector.difficulties)3)
        {
            chosenDifficulty = 3;
        }
        else if (diffsel.difficulty == (DifficultySelector.difficulties)4)
        {
            chosenDifficulty = 4;
        }
        else if (diffsel.difficulty == (DifficultySelector.difficulties)5)
        {
            chosenDifficulty = 5;
        }
        
        Debug.Log(chosenDifficulty);
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(LevelSceneName);
        
    }

    public void AssignStuff()
    {
        GameObject soldier = GameObject.Find("Soldier");
        GameObject spawnermanager = GameObject.Find("Spawner_Axis");
        GameObject hive = GameObject.Find("The Hive");

        soldier.GetComponent<Player_health>().maxhealth = PlayerHealth_Difficulties[chosenDifficulty - 1];
        soldier.GetComponent<Player_health>().health = PlayerHealth_Difficulties[chosenDifficulty - 1];

        spawnermanager.GetComponent<AllSpawners_Manager>().maxEnemiesInScene = EnemyInSceneCap_Difficulties[chosenDifficulty - 1];
        spawnermanager.GetComponent<AllSpawners_Manager>().enemiesPerWave = EnemyWaveCap_Difficulties[chosenDifficulty - 1];

        hive.GetComponent<Hive_Health>().currentHealth = HiveHealth_Difficulties[chosenDifficulty - 1];
        hive.GetComponent<Hive_Health>().maxHealth = HiveHealth_Difficulties[chosenDifficulty - 1];

        Destroy(gameObject);
    }
}
