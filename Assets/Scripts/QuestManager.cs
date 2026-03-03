using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    int amountToSpawn;
    int questToSpawn;

    public GameObject questPrefab; // Prefab for the quest UI element
    void Start()
    {
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            questToSpawn = Random.Range(1, 4);
            amountToSpawn = Random.Range(1, 11);
            if (questToSpawn == 1)
            {
                AddQuest("Collect " + amountToSpawn + " spellbooks");
            }
            else if (questToSpawn == 2)
            {
                AddQuest("Collect " + amountToSpawn + " wands");
            }
            else if (questToSpawn == 3)
            {
                AddQuest("Collect " + amountToSpawn + " herbs");
            }
        }
    }

    public void AddQuest(string QuestTitle)
    {
        GameObject quest = Instantiate(questPrefab, transform); // Create a new quest UI element as a child of the QuestManager
        quest.GetComponentInChildren<TMP_Text>().text = QuestTitle; // Set the quest description
        quest.GetComponentInChildren<QuestDetails>().requiredItem = amountToSpawn;
    }
}