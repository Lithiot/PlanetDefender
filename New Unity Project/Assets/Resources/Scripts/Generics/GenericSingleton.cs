using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    public virtual void Awake()
    {
        if(instance && instance != this)
            Destroy(this);
        else
        {
            instance = this as T;
            DontDestroyOnLoad(this);
        }
    }
}
