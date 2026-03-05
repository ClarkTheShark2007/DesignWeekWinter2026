using UnityEngine;

public class PhoneDespawner : MonoBehaviour
{
    int despawnTime = 30; // Time in seconds before the phone is despawned
    float currentTime = 0f;

    PhoneController phoneController;

    private void Start()
    {
        phoneController = GetComponent<PhoneController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        if (currentTime >= despawnTime)
        {
            phoneController.PhoneDisappears();
        }
    }
}
