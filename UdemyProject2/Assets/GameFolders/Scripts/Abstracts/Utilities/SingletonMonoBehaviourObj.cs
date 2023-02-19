using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Abstract.Utilities
{
    public abstract class SingletonMonoBehaviourObj<T> : MonoBehaviour where T:Component
    {
        public static T Instance { get; private set; }

        protected void SingletonThisObj(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
