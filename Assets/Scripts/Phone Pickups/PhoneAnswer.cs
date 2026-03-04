using UnityEngine;

public class PhoneAnswer : MonoBehaviour
{
    public QuestManager QuestManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void AnswerPhone(int typeOfPhone)
    {
        //1 = Modern Phone
        //2 = Flip Phone
        //3 = Rotary Phone
        //4 = Bannana Phone
        //5 = Payphone

        Debug.Log("Phone answered! Type of phone " + typeOfPhone);
        QuestManager.AddToList();
        // Add your logic here for what happens when the phone is answered
    }
}
