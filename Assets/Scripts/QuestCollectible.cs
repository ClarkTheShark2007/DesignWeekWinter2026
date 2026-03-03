using UnityEngine;

public class QuestCollectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object has a specific tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone!");
            // Example action: disable the object
            gameObject.SetActive(false);
        }
    }
}
