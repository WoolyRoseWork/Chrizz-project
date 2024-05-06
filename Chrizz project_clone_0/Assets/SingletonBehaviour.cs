using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _onQuit = false;

    public static T Instance
    {
        get
        {
            if (_instance == null && !_onQuit)
            {
                GameObject gameObject = new GameObject();
                gameObject.name = typeof(T).ToString();
                _instance = gameObject.AddComponent<T>();
                DontDestroyOnLoad(gameObject);
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
                DontDestroyOnLoad(gameObject);
            else
                Destroy(gameObject);
        }
    }

    private void OnApplicationQuit() => _onQuit = true;

    protected virtual void OnDestroy()
    {
        if (_instance != this)
            return;

        _instance = null;
    }
}
