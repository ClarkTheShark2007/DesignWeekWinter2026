using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public int phoneType;
    public bool calling = false;
    public PhoneSpawnPoint assignedSpawn;
    public GameObject[] turnOffOnCall;
    public GameObject[] turnOnOnCall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (calling)
        {
            if(turnOffOnCall.Length > 0)
            {
                foreach (GameObject go in turnOffOnCall)
                {
                    go.SetActive(false);
                }
            }
            if(turnOnOnCall.Length > 0)
            {
                foreach (GameObject go in turnOnOnCall)
                {
                    go.SetActive(true);
                }
            }
            calling = false;
        }
    }

    public void PhoneDisappears()
    {
        //get phone to disappear
        assignedSpawn.occupied = false;
        Destroy(gameObject);
    }
}
