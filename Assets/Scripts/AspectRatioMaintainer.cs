using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AspectRatioMaintainer : MonoBehaviour
{
    [Tooltip("Tries to lock the resolution at 1920x1080, with black bars on both sides")]
    public bool use;

    private List<GameObject> rootObjectsInScene = new List<GameObject>();
    // Start is called before the first frame update
    public IEnumerator Start()
    {
        yield return null;

        if (!use)
        {
            yield break;
        }

        GatherRootObjects();
        AddForcedAspectToCameras();
        RefreshCanvasScales();
        
    }

    public void RefreshAspectRatio()
    {
        StartCoroutine(RefreshAspectRatioCoroutine());
    }

    private IEnumerator RefreshAspectRatioCoroutine()
    {
        //Wait two frames so that new aspect ratio is applied
        yield return null;
        yield return null;
        RefreshForcedAspectCameras();
        RefreshCanvasScales();
    }

    private void RefreshCanvasScales()
    {
        ForcedAspect.CalculateScale();

        //all the canvas scalers, that are attached to canvas that have RenderMode - Screen Space - Camera should be constant pixel size, 
        //with scale factor = ForcedAspect.Scale

        for (int i = 0; i < rootObjectsInScene.Count; i++)
        {
            Canvas[] allComponents = rootObjectsInScene[i].GetComponentsInChildren<Canvas>(true);
            for (int j = 0; j < allComponents.Length; j++)
            {
                if (allComponents[j].renderMode == RenderMode.ScreenSpaceCamera)
                {
                    var scales = allComponents[j].gameObject.GetComponent<UnityEngine.UI.CanvasScaler>();
                    if (scales != null)
                    {
                        scales.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ConstantPixelSize;
                        scales.scaleFactor = ForcedAspect.CanvasScalerScaleFactor;
                    }
                }
            }
        }
    }

    private void RefreshForcedAspectCameras()
    {
        for (int i = 0; i < rootObjectsInScene.Count; i++)
        {
            ForcedAspect[] allComponents = rootObjectsInScene[i].GetComponentsInChildren<ForcedAspect>(true);
            for (int j = 0; j < allComponents.Length; j++)
            {
                allComponents[j].RefreshAspect();
            }
        }
    }

    private void AddForcedAspectToCameras()
    {
        for (int i = 0; i < rootObjectsInScene.Count; i++)
        {
            Camera[] allComponents = rootObjectsInScene[i].GetComponentsInChildren<Camera>(true);
            for (int j = 0; j < allComponents.Length; j++)
            {
                if (allComponents[j].gameObject != this.gameObject)
                {
                    if (allComponents[j].gameObject.GetComponent<ForcedAspect>() == null)
                    {
                        allComponents[j].gameObject.AddComponent<ForcedAspect>();
                    }
                }
            }
        }
    }

    private void GatherRootObjects()
    {
        rootObjectsInScene = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjectsInScene);
    }
}
