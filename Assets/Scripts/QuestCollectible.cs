using UnityEngine;

public class QuestCollectible : MonoBehaviour
{
    public int collectableType;
    //1 = spellbook
    //2 = wand
    //3 = herb

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

            //play little jingle
            Debug.Log("Player entered the trigger zone!");
            // Example action: disable the object
            gameObject.SetActive(false);
        }
    }
}
