using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    int amounttospawn;
    int questToSpawn;

    public GameObject questPrefab; // Prefab for the quest UI element
    void Start()
    {
        //AddQuest();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            questToSpawn = Random.Range(1, 4);
            if (questToSpawn == 1)
            {
                AddQuest("Collect 2 spellbooks");
            }
            else if (questToSpawn == 2)
            {
                AddQuest("Collect 10 Herbs");
            }
            else if (questToSpawn == 3)
            {
                AddQuest("Collect 1 Wand");
            }
        }
    }

    public void AddQuest(string QuestTitle)
    {
        GameObject quest = Instantiate(questPrefab, transform); // Create a new quest UI element as a child of the QuestManager
        quest.GetComponentInChildren<TMP_Text>().text = QuestTitle; // Set the quest description

    }
}
