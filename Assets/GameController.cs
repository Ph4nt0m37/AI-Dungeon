using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public List<GameObject> spawns = new List<GameObject>();

    public int difficulty = 1;

    public GameObject enemy1;
    // Start is called before the first frame update
    void Start()
    {
        spawns.Add(spawn1);
        spawns.Add(spawn2);
        spawns.Add(spawn3);
        spawns.Add(spawn4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startRound(int roundNum)
    {
        foreach (GameObject spawn in spawns)
        {
            spawnEnemy(enemy1, spawn);
        }
        difficulty = 1 * (roundNum / 4);
    }

    public void spawnEnemy(GameObject enemyType, GameObject spawn)
    {
        Instantiate(enemyType, spawn.transform);
    }
}
