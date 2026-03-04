using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public string questTitle;
    public string questDescription;
    public int questType;

    private Slider questSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questSlider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
