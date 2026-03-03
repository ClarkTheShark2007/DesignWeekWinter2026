using Unity.VisualScripting;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private bool lookingAtObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("looking at " + other.gameObject.name);
        }
    }
}
