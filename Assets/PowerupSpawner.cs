using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject speedPUPrefab, dashPUPrefab;
    public int speedCount, dashCount;

    [SerializeField] private float minX = 2, maxX = 6;
    [SerializeField] private float minZ = 2, maxZ = 6;
    [SerializeField] private float spawnCooldown = 5f;
    [SerializeField] private float spawnHeight = 5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerup", 0f, spawnCooldown);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPowerup()
    {
        if (speedCount == 3)
        {
            Debug.LogWarning("Powerup Limit REACHED!!!: " + speedCount);
            return;
        }

        if (dashCount == 5) 
        {
            Debug.Log("dash limit reached");                
            return;
        }

        float speedX = Random.Range(minX, maxX);
        float speedZ = Random.Range(minZ, maxZ);
        Vector3 speedPosition = new Vector3(speedX, spawnHeight, speedZ);

        Instantiate(speedPUPrefab, speedPosition, Quaternion.identity);

        float dashX = Random.Range(minX, maxX);
        float dashZ = Random.Range(minZ, maxZ);
        Vector3 dashPosition = new Vector3(dashX, spawnHeight, dashZ);

        Instantiate(dashPUPrefab, dashPosition, Quaternion.identity);

        speedCount++;
        dashCount++;
        
        Debug.LogWarning("Speed Limit: " + speedCount);
        Debug.LogWarning("Dash Limit: " + dashCount);
        
    }

    
}
