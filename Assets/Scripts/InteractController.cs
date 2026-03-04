using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private bool lookingAtObject;
    [SerializeField] private GameObject interactText;
    public static bool onPhone = false;
    private PhoneController lastPhoneLooked;
    [SerializeField] QuestManager questManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && lookingAtObject)
        {
            lastPhoneLooked.gameObject.GetComponent<PhoneController>().calling = true;
            interactText.SetActive(false);
            onPhone = true;

            questManager.AddToList();

            //pretend theres the message here
            onPhone = false;
            lastPhoneLooked.PhoneDisappears();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && other.gameObject.GetComponent<PhoneController>().calling == false)
        {
            interactText.SetActive(true);

            lastPhoneLooked = other.gameObject.GetComponent<PhoneController>();
            lookingAtObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            interactText.SetActive(false);
            
            lookingAtObject = false;
        }
    }

}
