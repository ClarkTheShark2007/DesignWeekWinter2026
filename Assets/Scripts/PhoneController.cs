using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public bool calling = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PhoneDisappears()
    {
        //get phone to disappear
        Destroy(gameObject);
    }
}
