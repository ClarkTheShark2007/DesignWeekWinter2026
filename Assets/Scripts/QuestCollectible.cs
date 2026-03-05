using UnityEngine;

public class QuestCollectible : MonoBehaviour
{
    public int collectableType;
    //1 = spellbook
    //2 = wand
    //3 = herb
    private PhoneSpawnPoint spawnScript;

    private void Start()
    {
        spawnScript = GetComponentInParent<PhoneSpawnPoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has a specific tag
        if (other.CompareTag("Player"))
        {
            if (collectableType == 1)
            {
                QuestManager.spellbooksNeeded--;
            }
            else if (collectableType == 2)
            {
                QuestManager.wandsNeeded--;
            }
            else if (collectableType == 3)
            {
                QuestManager.herbsNeeded--;
            }
            else if (collectableType == 4)
            {
                QuestManager.crystalsNeeded--;
            }
            else if (collectableType == 5)
            {
                QuestManager.potionsNeeded--;
            }

            //play little jingle

            spawnScript.occupied = false;

            Debug.Log("Player entered the trigger zone!");
            // Example action: disable the object
            gameObject.SetActive(false);
        }
    }
}
