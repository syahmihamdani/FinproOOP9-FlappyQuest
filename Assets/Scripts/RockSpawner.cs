using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject obstacle;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>maxTime){
            SpawnObstacle();
            timer = 0;
        }

        timer += Time.deltaTime;

    }

    private void SpawnObstacle(){
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject rock = Instantiate(obstacle, spawnPosition, Quaternion.identity);

        Destroy(rock, 6f);
    }
}
