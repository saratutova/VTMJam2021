using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ForcedAspect : MonoBehaviour
{
    //Attach this script to main camera, have an additional camera in the scene with chosen color for boxes
    //Set aspect ratio
    public static float Aspect_Width = 1920.0f;
    public static float Aspect_Height = 1080.0f;

    public static float CanvasScalerScaleFactor { get; private set; }

    public static void CalculateScale()
    {
        float targetaspect = Aspect_Width / Aspect_Height;
        // window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;
        // scale view by this amount
        
        float widthScale = (float)Screen.width / Aspect_Width;
        float heightScale = (float)Screen.height / Aspect_Height;

        CanvasScalerScaleFactor = Mathf.Min(widthScale, heightScale);
    }

    void Start()
    {
        RefreshAspect();
    }

    internal void RefreshAspect()
    {
        // calculate aspect
        float targetaspect = Aspect_Width / Aspect_Height;
        // window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;
        // scale view by this amount
        float scaleheight = windowaspect / targetaspect;
        // get the camera this script is attached to
        Camera camera = GetComponent<Camera>();
        // add letterbox
        if (scaleheight < 1.0f) //add letterbox
        {
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.y = (1.0f - scaleheight) / 2.0f;
            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;
            Rect rect = camera.rect;
            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            camera.rect = rect;
        }
    }
}
