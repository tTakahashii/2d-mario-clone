using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform defaultTarget;
    [SerializeField] private Vector3 offset;
    private Vector3 prePosition;
    private float preZoom = 5f;
    [SerializeField] private float defaultZoom = 5f, transitionSecond = 1f;

    [SerializeField] private ZoomPoint levelPoint;
    private ZoomPoint defaultPoint;

    private float positionTransitionTime = 0f, zoomTransitionTime = 0f, lerpTimer = 0f;
    private bool startedPositionTransition = false;

    // Start is called before the first frame update
    void Awake()
    {
        defaultPoint = new ZoomPoint(defaultTarget, defaultZoom);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
        {
            ZoomOnPoint(levelPoint, transitionSecond);
        }
        else
        {
            ZoomOnPoint(defaultPoint, 0.1f);
        }
    }

    public void ZoomOnPoint(ZoomPoint point, float transitionSecond)
    {
        //prePosition = prePosition == null ? point.zoomTarget.position : prePosition;

        //Debug.Log("Current target zoom level: " + point.zoomLevel);
        //Debug.Log("Current zoom level: " + cam.orthographicSize);
        //Debug.Log("Current pre-zoom level: " + preZoom);
        //Debug.Log("Current lerp timer: " + lerpTimer);

        if (!(Vector3.Distance(transform.position, offset + point.zoomTarget.position) < 0.1f))
        {
            if (!startedPositionTransition || prePosition != point.zoomTarget.position)
            {
                prePosition = point.zoomTarget.position;
                positionTransitionTime = Vector3.Distance(transform.position, offset + point.zoomTarget.position) / transitionSecond;
                zoomTransitionTime = (point.zoomLevel - cam.orthographicSize) / transitionSecond;
                startedPositionTransition = true;
            }

            lerpTimer += Time.deltaTime / transitionSecond;
            cam.orthographicSize = Mathf.Lerp(preZoom, point.zoomLevel, lerpTimer);
            transform.position = Vector3.MoveTowards(transform.position, offset + point.zoomTarget.position, positionTransitionTime * Time.deltaTime);
        }
        else
        {
            preZoom = cam.orthographicSize;
            positionTransitionTime = 0f;
            zoomTransitionTime = 0f;
            startedPositionTransition = false;
            lerpTimer = 0f;
        }   
    }
}