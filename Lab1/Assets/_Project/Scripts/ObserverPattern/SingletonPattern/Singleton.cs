using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace platformer397
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        public bool AutoUnparentOnAwake = true;
        protected static T Instance;
        public static bool HasInstance => Instance != null;
        public static T TryGetInstance() => HasInstance ? Instance : null;

        public static T instance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = FindAnyObjectByType<T>();
                    if (Instance == null)
                    {
                        var go = new GameObject(typeof(T).Name + "Generated");
                        Instance = go.AddComponent<T>();
                    }
                }
                return Instance;
            }

        }
        protected virtual void Awake()
        {
            if (AutoUnparentOnAwake) { transform.SetParent(null); }
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (Instance != this)
                {
                    Destroy(gameObject);
                }
            }
            
                
            

        }
    }
}
