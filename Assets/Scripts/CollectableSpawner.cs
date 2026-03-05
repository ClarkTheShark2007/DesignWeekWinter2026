using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject bookPrefab;
    public GameObject wandPrefab;
    public GameObject herbPrefab;
    public GameObject crystalPrefab;
    public GameObject potionPrefab;

    public GameObject bookSpawnParent;
    public GameObject wandSpawnParent;
    public GameObject herbSpawnParent;
    public GameObject crystalSpawnParent;
    public GameObject potionSpawnParent;

    private PhoneSpawnPoint[] bookSpawns;
    private PhoneSpawnPoint[] wandSpawns;
    private PhoneSpawnPoint[] herbSpawns;
    private PhoneSpawnPoint[] crystalSpawns;
    private PhoneSpawnPoint[] potionSpawns;

    public static List<GameObject> booksSpawned = new List<GameObject>();
    public static List<GameObject> wandsSpawned = new List<GameObject>();
    public static List<GameObject> herbsSpawned = new List<GameObject>();
    public static List<GameObject> crystalsSpawned = new List<GameObject>();
    public static List<GameObject> potionsSpawned = new List<GameObject>();

    private PhoneSpawnPoint[] tempArray;
    private GameObject tempPrefab;
    private List<GameObject> tempList;

    public GameObject tempPhoneHold;
    public GameObject tempCamera;

    int spawnsLeft;

    void Start()
    {
        bookSpawns = bookSpawnParent.GetComponentsInChildren<PhoneSpawnPoint>();
        wandSpawns = wandSpawnParent.GetComponentsInChildren<PhoneSpawnPoint>();
        herbSpawns = herbSpawnParent.GetComponentsInChildren<PhoneSpawnPoint>();
        crystalSpawns = crystalSpawnParent.GetComponentsInChildren<PhoneSpawnPoint>();
        potionSpawns = potionSpawnParent.GetComponentsInChildren<PhoneSpawnPoint>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //foreach(GameObject go in booksSpawned)
            //{
            //    Destroy(go);
            //}
            //foreach (GameObject go in wandsSpawned)
            //{
            //    Destroy(go);
            //}
            //foreach (GameObject go in herbsSpawned)
            //{
            //    Destroy(go);
            //}
        }

    }

    public void SpawnItems(int numOfSpawns, int collectType)
    {
        if (collectType == 1)
        {
            tempPrefab = bookPrefab;
            tempList = booksSpawned;
        }
        else if (collectType == 2)
        {
            tempPrefab = wandPrefab;
            tempList = wandsSpawned;
        }
        else if (collectType == 3)
        {
            tempPrefab = herbPrefab;
            tempList = herbsSpawned;
        }
        else if (collectType == 4)
        {
            tempPrefab = crystalPrefab;
            tempList = crystalsSpawned;
        }
        else if (collectType == 5)
        {
            tempPrefab = potionPrefab;
            tempList = potionsSpawned;
        }

        for (int i = 0; i < numOfSpawns; i++)
        {
            PhoneSpawnPoint emptyPoint = FindEmptyPoint(collectType);
            if (collectType == 1)
            {
                booksSpawned.Add(Instantiate(tempPrefab, emptyPoint.transform));
            }
            else if (collectType == 2)
            {
                wandsSpawned.Add(Instantiate(tempPrefab, emptyPoint.transform));
            }
            else if (collectType == 3)
            {
                herbsSpawned.Add(Instantiate(tempPrefab, emptyPoint.transform));
            }
            else if (collectType == 4)
            {
                crystalsSpawned.Add(Instantiate(tempPrefab, emptyPoint.transform));
            }
            else if (collectType == 5)
            {
                potionsSpawned.Add(Instantiate(tempPrefab, emptyPoint.transform));
            }
            emptyPoint.occupied = true;
        }

    }

    public PhoneSpawnPoint FindEmptyPoint(int collectType)
    {
        if (collectType == 1)
        {
            tempArray = bookSpawns;
        }
        else if (collectType == 2)
        {
            tempArray = wandSpawns;
        }
        else if (collectType == 3)
        {
            tempArray = herbSpawns;
        }
        else if (collectType == 4)
        {
            tempArray = crystalSpawns;
        }
        else if (collectType == 5)
        {
            tempArray = potionSpawns;
        }

        PhoneSpawnPoint possiblePoint = tempArray[Random.Range(0, tempArray.Length)];
        if (!possiblePoint.occupied)
        {
            return possiblePoint;
        }
        else
        {
            return FindEmptyPoint(collectType);
        }
    }
}
