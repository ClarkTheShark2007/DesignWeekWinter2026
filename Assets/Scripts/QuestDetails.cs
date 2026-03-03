using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QuestDetails : MonoBehaviour
{

    public int collectedItem;
    public int requiredItem;
    public Slider progressSlider;
    public TextMeshProUGUI progressValue;

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
        progressValue.text = collectedItem + "/" + requiredItem;
        progressSlider.value = collectedItem;

        if(collectedItem >= requiredItem)
        {
                Destroy(QuestObject); // Destroy the quest UI element when the quest is completed
        }
    }
}
