using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionEffect;
    void OnCollisionEnter(Collision collision)
    {
        explosionEffect.SetActive(true);
        StartCoroutine(DestroyAfterEffect());
    }
    IEnumerator DestroyAfterEffect()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        explosionEffect.SetActive(false);
    }
}
