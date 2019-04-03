using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    /*
     *Camera shake code based on code taken from:
     * https://gist.github.com/ftvs/5822103
    */

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    [SerializeField]
    private Transform camTransform;

    // How long the object should shake for.
    [SerializeField]
    private float timeToShake = .1f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    [SerializeField]
    private float shakeAmount = 0.7f;
    [SerializeField]
    private float decreaseFactor = 1.0f;

    private Vector3 originalPos;
    private float shakeDuration = 0f;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    public void StartShaking()
    {
        StopCoroutine("ShakeCamera");
        StartCoroutine("ShakeCamera", timeToShake);
    }

    private IEnumerator ShakeCamera(float timeToShake)
    {
        camTransform.localPosition = originalPos;
        shakeDuration = timeToShake;
        while (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
            yield return null;
        }
        shakeDuration = 0f;
        camTransform.localPosition = originalPos;
    }
}
