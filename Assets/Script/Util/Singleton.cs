using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> {
    protected static T _instance = null;
    
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                    _instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
            }
            return _instance;
        }
    }

    public abstract void Init();

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            _instance.Init();
        }
    }

    public virtual void OnApplicationQuit()
    {
        _instance = null;
    }
}
