using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneStuff : MonoBehaviour
{
    [SerializeField] private List<Interaction> interactions = new List<Interaction>();

    public bool IsThereSometingImportant => interactions.Any(x => x.important && !x.clicked);
    public bool IsThereSometingToClick => interactions.Any(x => !x.clicked);


    internal void Init()
    {
        gameObject.SetActive(true);
    }

    internal void Disable()
    {
        gameObject.SetActive(false);
    }
}
