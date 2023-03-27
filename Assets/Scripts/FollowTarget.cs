using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            this.enabled = false;
        }
        else
        {
            transform.position = target.position + offset;
        }              
    }
}
