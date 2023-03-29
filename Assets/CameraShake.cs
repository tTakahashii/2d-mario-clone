using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float xMinMax, yMinMax;

    private Vector3 originalPosition;
    private float timer = 0f, secondaryTimer = 0f;

    private Vector2 RandomVector2(float xMinMax, float yMinMax)
    {
        return new Vector2(Random.Range(-xMinMax, xMinMax), Random.Range(-yMinMax, yMinMax));
    }

    public IEnumerator Shake(float xMinMax, float yMinMax, float shakeDuration, float shakePerSecond)
    {
        //originalPosition = originalPosition == null ? transform.position : originalPosition;
        originalPosition = transform.localPosition;

        while (timer <= shakeDuration)
        {
            timer += Time.deltaTime;

            if (secondaryTimer <= 1f / shakePerSecond)
            {
                secondaryTimer += Time.deltaTime;
            }

            else
            {
                secondaryTimer = 0f;
                transform.localPosition = RandomVector2(xMinMax, yMinMax);
            }

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
