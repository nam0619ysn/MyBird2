using UnityEngine;
namespace Sample.Generic {
    public class PersistanceSingleton<T> : Singleton<T> where T : Singleton<T>
    {
        protected override void Awake()
        {
            base.Awake();
            //씬 전환시 파괴되지 않는다.
            DontDestroyOnLoad(gameObject);
        }
    }
}   