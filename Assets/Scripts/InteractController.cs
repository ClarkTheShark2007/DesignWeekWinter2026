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
    public GameObject[] minigames;

    private GameObject cameraGO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraGO = GetComponentInParent<Camera>().gameObject;
        Debug.Log(cameraGO.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && lookingAtObject && lastPhoneLooked)
        {
            
            PhoneController lastPhoneScript = lastPhoneLooked.gameObject.GetComponent<PhoneController>();
            lastPhoneScript.calling = true;

            minigames[lastPhoneScript.phoneType - 1].SetActive(true);

            interactText.SetActive(false);
            onPhone = true;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            lastPhoneLooked.PhoneDisappears();
        }

        if (Input.GetMouseButtonDown(1) && PhoneAnswer.phoneInHand)
        {

            PhoneAnswer.phoneInHand.transform.SetParent(null);
            PhoneAnswer.phoneInHand.GetComponentInChildren<Collider>().enabled = true;
            PhoneAnswer.phoneInHand.GetComponentInChildren<Rigidbody>().AddForce(cameraGO.transform.forward * 5000);
            PhoneAnswer.phoneInHand.GetComponentInChildren<Rigidbody>().useGravity = true;
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
