using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuestDetails : MonoBehaviour
{
    public int collectableType;

    public int collectedItem;
    public int requiredItem;
    public Slider progressSlider;
    public TextMeshProUGUI progressValue;

    public static bool countCollectable;

    public GameObject QuestObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressSlider.wholeNumbers = true;
        progressSlider.minValue = 0;
        progressSlider.maxValue = requiredItem;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectableType == 1)
        {
            collectedItem = requiredItem - QuestManager.spellbooksNeeded;
        }
        else if (collectableType == 2) 
        {
            collectedItem = requiredItem - QuestManager.wandsNeeded;
        }
        else if (collectableType == 3)
        {
            collectedItem = requiredItem - QuestManager.herbsNeeded;
        }

        progressValue.text = collectedItem + "/" + requiredItem;
        progressSlider.value = collectedItem;

        if(collectedItem >= requiredItem)
        {
            //add more effects that quest has been completed, maybe big text on screen
                Destroy(QuestObject); // Destroy the quest UI element when the quest is completed
        }
    }
}
