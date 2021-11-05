using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager<T> : Manager where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance 
    { 
        get 
        {
            if (_instance != null)
            {
                return _instance;
            }
            Debug.LogError($"Manager {typeof(T)} was null");
            return null;
        } 
    }

    protected virtual void Awake()
    {
        _instance = this as T;
    }
}

public abstract class Manager : MonoBehaviour
{

}