using UnityEngine;
namespace Sample.Generic
{
    public class Singleton<T> : MonoBehaviour where T:Singleton<T>
    {
        //클래스의 인스턴스 변수를 정적(static)변수로 선언
        private static T instance;

        //public한 속성로 instance를 전역적으로 접근하기
        public static T Instance
        {
            get
            {
                return instance;
            }
        }
        public static bool InstanceExist
        {
            get
            {
                return instance != null;
            }
        }
        protected virtual void Awake()
        {
            //싱긍톤을 가진 오브젝트가 이미 존재하면  
            if (instance != null)
            {
                //오브젝트 킬
                Destroy(gameObject);
                return;
            }
            instance = (T)this;
            
        }

    }
}