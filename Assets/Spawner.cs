using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRange;
    public GameObject[] WhatToSpawn = {};
    public float SpawnRate;
    public float pickUpRange;
    public Transform playerTransform;
    public PC_Controller player;


    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn) {
            SpawnRandom(WhatToSpawn);
            nextSpawn = SpawnRate + Time.time;
        }
    }

    void Spawn(GameObject obj) {
        float pos = Random.Range(-spawnRange, spawnRange);
        Vector3 location = new Vector3(pos, -10, 0);
        GameObject newObj = Instantiate (obj, location, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        newObj.GetComponent<MoveUp>().SetValues(pickUpRange, playerTransform, player);
    }

    void SpawnRandom(GameObject[] objects) {
        int type = Random.Range(0, objects.Length);
        Spawn(objects[type]);
    }
}
