using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPoint : MonoBehaviour
{
    public float zoomLevel;
    [HideInInspector] public Transform zoomTarget;

    public ZoomPoint(Transform pointDefault, float zoomDefault)
    {
        zoomTarget = pointDefault;
        zoomLevel = zoomDefault;
    }

    private void Awake()
    {
        zoomTarget = transform;
    }
}
