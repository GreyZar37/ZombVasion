using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject zombiePrefab;

    public float spawnCooldown;
    float currentTimer;

    int randomSpawnPoint;


    public string ZombieTag;
    public GameObject[] currentZombiest;
    public int maxZombies;
    bool canSpawn;


    private void Start()
    {
        currentTimer = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {

        currentTimer -= Time.deltaTime;
        randomSpawnPoint = Random.Range(0, spawnPoints.Length);

        currentZombiest = GameObject.FindGameObjectsWithTag(ZombieTag);

        if(currentZombiest.Length > maxZombies)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }

        if (currentTimer <= 0 && canSpawn == true)
        {
            Instantiate(zombiePrefab, new Vector2 (spawnPoints[randomSpawnPoint].transform.position.x, spawnPoints[randomSpawnPoint].transform.position.y),Quaternion.identity);
            currentTimer = spawnCooldown;
        }

    }
}
