using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject cube;

    private int enemiesSpawned;

    [SerializeField] private float minX = 2, maxX = 6;
    [SerializeField] private float minZ = 2, maxZ = 6;
    [SerializeField] private float spawnCooldown = 5f;
    [SerializeField] private float spawnHeight = 5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnCooldown);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy()
    {
        // if (enemiesSpawned == 10)
        // {
        //     Debug.LogWarning("Enemy Limit REACHED!!!: " + enemiesSpawned);
        //     return;
        // }

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, spawnHeight, randomZ);

        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        enemiesSpawned++;
        Debug.LogWarning("Enemy Limit: " + enemiesSpawned);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            Debug.LogWarning("collided");
        }
    }
}
