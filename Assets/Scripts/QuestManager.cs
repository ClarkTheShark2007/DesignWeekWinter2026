using System.Collections;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{

    int amountToSpawn;
    int questToSpawn;
    bool isCallerTalking = false;

    public GameObject questPrefab; // Prefab for the quest UI element
    public TextMeshProUGUI callerSpeachText; // Text for the caller speech UI element
    public GameObject callerSpeach; // caller UI element

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //questToSpawn = Random.Range(1, 4);
            //amountToSpawn = Random.Range(1, 11);
            //if (questToSpawn == 1)
            //{
            //    AddQuest("Collect " + amountToSpawn + " spellbooks", "I want " + amountToSpawn + " spellbooks pls");
            //}
            //else if (questToSpawn == 2)
            //{
            //    AddQuest("Collect " + amountToSpawn + " wands", "Where is my " + amountToSpawn + " wands from that greedy wizard? GET IT TO ME NOW");
            //}
            //else if (questToSpawn == 3)
            //{
            //    AddQuest("Collect " + amountToSpawn + " herbs", "I would love " + amountToSpawn + " herbs from the wizards");
            //}
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            callerSpeach.gameObject.SetActive(false); // Hide the caller speech text when the right mouse button is pressed (Can be diffretn just as an example)
        }

    }

    public void AddQuest(string QuestTitle, string callerSpeech)
    {
        GameObject quest = Instantiate(questPrefab, transform); // Create a new quest UI element as a child of the QuestManager

        quest.GetComponentInChildren<TMP_Text>().text = QuestTitle; // Set the quest description
        quest.GetComponentInChildren<QuestDetails>().requiredItem = amountToSpawn;

        StartCoroutine(StartCallerSpeech(callerSpeech)); // Start the typewriter effect for the caller's speech

    }

    IEnumerator StartCallerSpeech(string message)
    {
        callerSpeach.gameObject.SetActive(true);
        callerSpeachText.text = message; //Make the text mesh's content the whole message string right at the beginning. So the characters will stay at the correct positions since the beginning

        callerSpeachText.maxVisibleCharacters = 0;
        int messageCharLength = message.Length;
        while (callerSpeachText.maxVisibleCharacters < messageCharLength)
        {
            callerSpeachText.maxVisibleCharacters++;
            yield return new WaitForSeconds(0.05f);
        }

        isCallerTalking = false;
        print("Typewriter effect is completed");
    }

    public void AddToList()
    {
        questToSpawn = Random.Range(1, 4);
        amountToSpawn = Random.Range(1, 11);
        if (questToSpawn == 1)
        {
            AddQuest("Collect " + amountToSpawn + " spellbooks", "I want " + amountToSpawn + " spellbooks pls");
        }
        else if (questToSpawn == 2)
        {
            AddQuest("Collect " + amountToSpawn + " wands", "Where is my " + amountToSpawn + " wands from that greedy wizard? GET IT TO ME NOW");
        }
        else if (questToSpawn == 3)
        {
            AddQuest("Collect " + amountToSpawn + " herbs", "I would love " + amountToSpawn + " herbs from the wizards");
        }
    }

    public void Speak()
    {

    }
}