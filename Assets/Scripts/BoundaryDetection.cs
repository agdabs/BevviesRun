using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDetection : MonoBehaviour
{

    public Transform target;
    Camera cam;
    public float LBoundary;
    public float RBoundary;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        LBoundary = 0.37f;
        RBoundary = 0.63f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(target.position);

        if (viewPos.x < LBoundary)
        {
            print("oof too left");
        } else if (viewPos.x > RBoundary)
        {
            print("yikes too right");
        }

    }
}
