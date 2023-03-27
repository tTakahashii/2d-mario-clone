using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float spinPerSecond = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, (spinPerSecond * 360f) * Time.deltaTime);
    }
}
