using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIView : SceneView
{
    protected override void OnRefresh()
    {
        gameObject.SetActive(_model.ShouldUIBeVisible);
    }
}
