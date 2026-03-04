using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SliderCheck : MonoBehaviour, IPointerUpHandler
{
    public int SliderMaxValue = 1;
    public Slider progressSlider;
    public PhoneAnswer phoneAnswer;
    public int TypeOfPhone; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressSlider.minValue = 0;
        progressSlider.maxValue = SliderMaxValue;
        phoneAnswer = GetComponent<PhoneAnswer>();
    }

    // Update is called once per frame
    void Update()
    {
        float sliderValue = progressSlider.value;
        Debug.Log("Current Slider Value: " + sliderValue);

        if (sliderValue >= 1)
        {
            phoneAnswer.AnswerPhone(TypeOfPhone);
            progressSlider.value = 0;
            gameObject.SetActive(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Let go of.");
        progressSlider.value = 0; // Reset the slider value to 0 when the pointer is released


    }
}
