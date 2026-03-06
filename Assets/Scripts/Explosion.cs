using System.Collections;
using UnityEngine;
using PrimeTween;


public class Explosion : MonoBehaviour
{
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    public GameObject explosionEffect;
    void OnCollisionEnter(Collision collision)
    {
        explosionEffect.SetActive(true);
        //Tween.ShakeCamera(mainCamera, strengthFactor: 1f);
        StartCoroutine(DestroyAfterEffect());
    }
    IEnumerator DestroyAfterEffect()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        explosionEffect.SetActive(false);
    }
}
