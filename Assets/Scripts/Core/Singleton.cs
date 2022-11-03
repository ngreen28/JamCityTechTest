using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T instance
        {
            get
            {
                if (_instance == null)
                {
                    var objs = FindObjectsOfType(typeof(T)) as T[];
                    if (objs != null && objs.Length > 0)
                        _instance = objs[0];
                    if (objs != null && objs.Length > 1)
                    {
                        throw new System.Exception("There is more than one " + typeof(T).Name + " in the scene.");
                    }

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject {name = $"_{typeof(T).Name}"};
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
    }
}
