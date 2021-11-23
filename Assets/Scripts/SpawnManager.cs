using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemiesPrefab;
    public List<GameObject> friendsPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 15;
    public bool isGameActive = true;
    private float spawnRate = 1.0f;
    private float numberOfFriends = 5;
    public int waveCount = 1;
    private int friendCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        friendCount = GameObject.FindGameObjectsWithTag("Friend").Length;
        if (waveCount < 5)
        {
            if (friendCount == 0)
            {
                SpawnWave(waveCount);
            }
        }
        else
        {
            isGameActive = false;
        }

    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 1f ,Random.Range(-spawnRange, spawnRange));
    }
    IEnumerator SpawnEnemies()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, enemiesPrefab.Count);
            Instantiate(enemiesPrefab[index],RandomSpawnPos(),enemiesPrefab[index].transform.rotation);


        }
    }
    IEnumerator SpawnFriends()
    {
        while (numberOfFriends>0)
        {
            yield return new WaitForSeconds(spawnRate*2);
            int index = Random.Range(0, friendsPrefab.Count);
            Instantiate(friendsPrefab[index], RandomSpawnPos(), friendsPrefab[index].transform.rotation);
        }
    }
    void SpawnWave(int friendsToSpawn)
    {
       

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("PowerUp").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, RandomSpawnPos(), powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < friendsToSpawn; i++)
        {
            int indexf = Random.Range(0, friendsPrefab.Count);
            Instantiate(friendsPrefab[indexf], RandomSpawnPos(), friendsPrefab[indexf].transform.rotation);
        }
        for (int i = 0; i < friendsToSpawn-1; i++)
        {
            int index = Random.Range(0, enemiesPrefab.Count);
            Instantiate(enemiesPrefab[index], RandomSpawnPos(), enemiesPrefab[index].transform.rotation);
        }
        waveCount++;

     }


}
