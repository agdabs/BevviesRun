using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Collectible")
        {
            Debug.Log("Collected: " + obj.name);
            Destroy(obj);
        }
    }
}
