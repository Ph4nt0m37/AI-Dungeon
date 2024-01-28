using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public List<GameObject> spawns = new List<GameObject>();
    public TextMeshProUGUI roundText;
    public int enemyCount = 0;

    public float difficulty = 1f;
    public int roundNum = 1;

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
        if (enemyCount <= 0)
        {
            roundText.text = "Press space to\ngo to next\nround";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startRound(roundNum);
                roundNum++;
            }
        }
    }

    public void startRound(int roundNum)
    {
        roundText.text = "Round " + roundNum;
        for (int i = 0; i < roundNum; i++)
        {
            foreach (GameObject spawn in spawns)
            {
                spawnEnemy(enemy1, spawn);
            }
        }
        difficulty = 1 + (roundNum / 8);
    }

    public void spawnEnemy(GameObject enemyType, GameObject spawn)
    {
        Instantiate(enemyType, spawn.transform);
        enemyCount++;
    }
}
