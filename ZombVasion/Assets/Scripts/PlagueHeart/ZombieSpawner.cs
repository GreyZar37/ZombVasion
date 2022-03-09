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


    public List<GameObject> currentZombies = new List<GameObject>();

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

        for (int i = 0; i < currentZombies.Count; i++)
        {
            if (currentZombies[i] == null)
                currentZombies.RemoveAt(i);
        }


        if (currentZombies.Count > maxZombies)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }

        if (currentTimer <= 0 && canSpawn == true)
        {
            currentZombies.Add(Instantiate(zombiePrefab, new Vector2 (spawnPoints[randomSpawnPoint].transform.position.x, spawnPoints[randomSpawnPoint].transform.position.y),Quaternion.identity));
            currentTimer = spawnCooldown;
        }

    }
}
