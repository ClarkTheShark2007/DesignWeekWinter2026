using UnityEngine;

public class PhoneAnswer : MonoBehaviour
{
    public QuestManager QuestManager;
    public GameObject[] throwablePhonePrefabs;
    public GameObject cameraGO;

    public static GameObject phoneInHand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AnswerPhone(int typeOfPhone)
    {
        //1 = Modern Phone
        //2 = Flip Phone
        //3 = Rotary Phone
        //4 = Bannana Phone
        //5 = Payphone

        InteractController.onPhone = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        phoneInHand = Instantiate(throwablePhonePrefabs[typeOfPhone - 1], cameraGO.transform);
        phoneInHand.transform.localPosition = Vector3.zero;

        Debug.Log("Phone answered! Type of phone " + typeOfPhone);
        QuestManager.AddToList();
        // Add your logic here for what happens when the phone is answered
    }
}
