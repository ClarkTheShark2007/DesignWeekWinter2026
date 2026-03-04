using UnityEngine;

public class BannaPhone : MonoBehaviour
{
    public int TotalPeels = 3;
    public int CurrentPeel;
    public PhoneAnswer phoneAnswer;

    public GameObject[] peels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phoneAnswer = GetComponent<PhoneAnswer>();
        CurrentPeel = TotalPeels;
    }
    public void RemovePeel()
    {
        CurrentPeel--;
        if(CurrentPeel <= 0)
        {
            Debug.Log("Phone is fully peeled!");
            phoneAnswer.AnswerPhone(4);
            gameObject.SetActive(false);
            CurrentPeel = TotalPeels;

            for (int i = 0; i < peels.Length; i++)
            {
                peels[i].SetActive(true);
            }
        }
    }
}
