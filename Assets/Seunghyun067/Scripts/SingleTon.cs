using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        [SerializeField] private bool isSceneChangeDestory = false;

        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (!instance)
                    {
                        GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                        instance = obj.GetComponent<T>();
                    }
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (isSceneChangeDestory) return;

            if (transform.parent != null && transform.root != null)
                DontDestroyOnLoad(this.transform.root.gameObject);
            else
                DontDestroyOnLoad(this.gameObject);
        }
    }
}
