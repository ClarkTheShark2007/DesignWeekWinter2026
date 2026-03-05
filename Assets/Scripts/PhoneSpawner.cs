using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PhoneSpawner : MonoBehaviour
{
    public GameObject possibleLocationsParent;
    public PhoneSpawnPoint[] spawnlocations;
    public GameObject[] phonePrefabs;

    [SerializeField] float spawnTimer;
    [SerializeField] float spawnPause;

    private bool keepSpawning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnlocations = possibleLocationsParent.GetComponentsInChildren<PhoneSpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnPause)
        {
            if (CheckIfEmpty())
            {
                PhoneSpawnPoint emptyPoint = FindEmptyPoint();

                int phoneType = Random.Range(0, 5);

                GameObject newPhone = Instantiate(phonePrefabs[phoneType], emptyPoint.gameObject.transform);
                newPhone.GetComponent<PhoneController>().assignedSpawn = emptyPoint;
                emptyPoint.occupied = true;
            }
            spawnTimer = 0;
        }
    }

    public bool CheckIfEmpty()
    {
        for(int i = 0; i < spawnlocations.Length; i++)
        {
            if (!spawnlocations[i].occupied) return true;
        }
        return false;
    }

    public PhoneSpawnPoint FindEmptyPoint()
    {
        PhoneSpawnPoint possiblePoint = spawnlocations[Random.Range(0, spawnlocations.Length)];
        if (!possiblePoint.occupied)
        {
            return possiblePoint;
        }
        else
        {
            return FindEmptyPoint();
        }
    }
}
