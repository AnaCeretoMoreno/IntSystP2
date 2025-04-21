using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    
    public GameObject sheepPrefab; 
    public List<Transform> sheepSpawnPositions = new List<Transform>(); 
    
    public float initialTimeBetweenSpawns;
    public float increaseSpawnsSecods; 

    private float currentTimeBetweenSpawns;

    private List<GameObject> sheepList = new List<GameObject>(); 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTimeBetweenSpawns = initialTimeBetweenSpawns;
        StartCoroutine(SpawnRoutine());
        StartCoroutine(IncreaseSpawnRate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
    }

    private IEnumerator SpawnRoutine() 
    {
        while (canSpawn) 
        {
            SpawnSheep(); 
            yield return new WaitForSeconds(currentTimeBetweenSpawns); 
        }
    }

    private IEnumerator IncreaseSpawnRate()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(10f); // Every 10 secods

            currentTimeBetweenSpawns -= increaseSpawnsSecods; // Reduce spawn interval

            currentTimeBetweenSpawns = Mathf.Max(currentTimeBetweenSpawns, 1.0f); // The max speed of spawn is 1 sheep/sec
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList) 
        {
            Destroy(sheep); 
        }

        sheepList.Clear();
    }


}
