using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject player;
    public GameObject powerUp;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Instantiate(powerUp, GenerateSpawnPos(), Quaternion.identity);

        SpawnEnemyWave();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            SpawnEnemyWave();
            Instantiate(powerUp, GenerateSpawnPos(), Quaternion.identity);
        }
    }
    void SpawnEnemyWave()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), player.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-15, 15);
        float spawnPosZ = Random.Range(-15, 15);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
