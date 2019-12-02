using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseViewportRotator : MonoBehaviour
{

    void Update()
    {
        Camera cam = Camera.main;
        Vector3[] frustumCorners = new Vector3[4];   
        cam.CalculateFrustumCorners(new Rect(0,0,1,1), cam.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);

         for (int i = 0; i < 4; i++)
        {
            var worldSpaceCorner = cam.transform.TransformVector(frustumCorners[i]);
            Debug.DrawRay(cam.transform.position, worldSpaceCorner, Color.blue);
        }

        cam.CalculateFrustumCorners(new Rect(0, 0, 1, 1), cam.farClipPlane, Camera.MonoOrStereoscopicEye.Left, frustumCorners);

        for (int i = 0; i < 4; i++)
        {
            var worldSpaceCorner = cam.transform.TransformVector(frustumCorners[i]);
            Debug.DrawRay(cam.transform.position, worldSpaceCorner, Color.green);
        }

        cam.CalculateFrustumCorners(new Rect(0, 0, 1, 1), cam.farClipPlane, Camera.MonoOrStereoscopicEye.Right, frustumCorners);

        for (int i = 0; i < 4; i++)
        {
            var worldSpaceCorner = cam.transform.TransformVector(frustumCorners[i]);
            Debug.DrawRay(cam.transform.position, worldSpaceCorner, Color.red);
        }
    }
}
