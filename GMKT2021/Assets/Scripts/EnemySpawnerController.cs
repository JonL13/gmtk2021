using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public int maxEnemiesToSpawn = 10;
    public float spawnRateInSeconds = 5;

    private float spawnTimer = 0;
    private int enemiesSpawned = 0;


    void Start(){
        
    }

    void Update(){
        if(enemiesSpawned >= maxEnemiesToSpawn) {
            return;
        }

        if (spawnTimer < spawnRateInSeconds) {
            spawnTimer += Time.deltaTime;
        } else {
            spawnEnemy();
        }
    }

    private void spawnEnemy() {
        Vector3 spawnPosition = gameObject.transform.position;
        GameObject enemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity) as GameObject;
        enemy.transform.parent = gameObject.transform;

        spawnTimer = 0;
        enemiesSpawned += 1;
    }
}
