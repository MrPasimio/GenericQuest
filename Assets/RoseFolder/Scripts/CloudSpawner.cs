using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{//Variables
    public GameObject[] cloudPrefab;
    public float spawnDelay;
    public float spawnInterval;
    public float yRange = 3f;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("spawnClouds", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnClouds()
    {
        int cloudIndex = Random.Range(0, cloudPrefab.Length);
        float y = Random.Range(-yRange, yRange);
            Vector2 spawnPoint = new Vector2(transform.position.x, 1 + y);
            Instantiate(cloudPrefab[cloudIndex], spawnPoint, cloudPrefab[cloudIndex].transform.rotation);
        
    }



}
