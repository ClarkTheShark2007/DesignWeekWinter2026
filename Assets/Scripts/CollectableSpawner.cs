using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject bookPrefab;
    public GameObject wandPrefab;
    public GameObject herbPrefab;

    public GameObject bookSpawnParent;
    public GameObject wandSpawnParent;
    public GameObject herbSpawnParent;

    private PhoneSpawnPoint[] bookSpawns;
    private PhoneSpawnPoint[] wandSpawns;
    private PhoneSpawnPoint[] herbSpawns;

    public static List<GameObject> booksSpawned = new List<GameObject>();
    public static List<GameObject> wandsSpawned = new List<GameObject>();
    public static List<GameObject> herbsSpawned = new List<GameObject>();

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            tempPhoneHold.transform.parent = null;
            tempPhoneHold.GetComponentInChildren<Collider>().enabled = true;
            tempPhoneHold.GetComponent<Rigidbody>().AddForce(tempCamera.transform.forward * 5000);
            tempPhoneHold.GetComponent<Rigidbody>().useGravity = true;

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

        for(int i = 0; i < numOfSpawns; i++)
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
