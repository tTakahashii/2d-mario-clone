using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSticking : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.SetParent(null);
    }
}
