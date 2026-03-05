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

    public static int spellbooksNeeded;
    public static int wandsNeeded;
    public static int herbsNeeded;
    public static int crystalsNeeded;
    public static int potionsNeeded;

    public CollectableSpawner spawnerScript;

    private void Start()
    {
        spellbooksNeeded = 0;
        wandsNeeded = 0;
        herbsNeeded = 0;
        crystalsNeeded = 0;
        potionsNeeded = 0;
}

    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            callerSpeach.gameObject.SetActive(false); // Hide the caller speech text when the right mouse button is pressed (Can be diffretn just as an example)
        }

    }

    public void AddQuest(bool giveQuest, int objectType, string QuestTitle, string callerSpeech)
    {
        if(giveQuest)
        {
            GameObject quest = Instantiate(questPrefab, transform); // Create a new quest UI element as a child of the QuestManager
            quest.GetComponentInChildren<TMP_Text>().text = QuestTitle; // Set the quest description
            quest.GetComponentInChildren<QuestDetails>().requiredItem = amountToSpawn;

            QuestDetails details = quest.GetComponentInChildren<QuestDetails>();
            details.collectableType = objectType;

            spawnerScript.SpawnItems(amountToSpawn, objectType);
        }
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
        questToSpawn = Random.Range(1, 6);

        amountToSpawn = Random.Range(2, 5); //there have to be at least one less number spawn points in the game world for each item

        if (questToSpawn == 1)
        {
            if (spellbooksNeeded <= 0)
            {
                spellbooksNeeded = amountToSpawn;
                AddQuest(true, questToSpawn, "Collect " + amountToSpawn + " spellbooks", "I want " + amountToSpawn + " spellbooks please.");

            }
            else
            {
                AddQuest(false, questToSpawn, "DOESNT MATTER", "Hey buddy, do you have a moment to talk about vacuum cleaners?");
            }
        }
        else if (questToSpawn == 2)
        {
            if (wandsNeeded <= 0)
            {
                wandsNeeded = amountToSpawn;
                AddQuest(true, questToSpawn, "Collect " + amountToSpawn + " wands", "Where are my " + amountToSpawn + " wands from that greedy wizard? I asked for these days ago!");
            }
            else
            {
                AddQuest(false, questToSpawn, "DOESNT MATTER", "Your security information has been found in a privacy breach. Stay on the line while we figure out how to solve the issue.");
            }
        }
        else if (questToSpawn == 3)
        {
            if (herbsNeeded <= 0)
            {
                herbsNeeded = amountToSpawn;
                AddQuest(true, questToSpawn, "Collect " + amountToSpawn + " herbs", "I would love " + amountToSpawn + " herbs from the wizard. The wizard is so kind.");
            }
            else
            {
                AddQuest(false, questToSpawn, "DOESNT MATTER", "You have won 1,000,000 pieces of gold! Please state your banking information to have us deposit the gold in your account.");
            }
        }
        else if (questToSpawn == 4)
        {
            if (crystalsNeeded <= 0)
            {
                crystalsNeeded = amountToSpawn;
                AddQuest(true, questToSpawn, "Collect " + amountToSpawn + " crystals", "Hey man, I really need " + amountToSpawn + " crystals. You mind sending some over?");
            }
            else
            {
                AddQuest(false, questToSpawn, "DOESNT MATTER", "This is the wizard checking in. Is everything running smoothly? I've been recieving some complaints regarding long hold times. Do better, my student.");
            }
        }
        else if (questToSpawn == 5)
        {
            if (potionsNeeded <= 0)
            {
                potionsNeeded = amountToSpawn;
                AddQuest(true, questToSpawn, "Collect " + amountToSpawn + " potions", "Yo, you got some potions? Gimme " + amountToSpawn + ", yo.");
            }
            else
            {
                AddQuest(false, questToSpawn, "DOESNT MATTER", "Hello? Hello, hello? Uh… I wanted to record a message for you to help you get settled in on your first night. Um… I actually worked in that office before you. I'm…finishing up my last week now, as a matter of fact, so… I know it can be a bit overwhelming.");
            }
        }
    }

    public void Speak()
    {

    }
}