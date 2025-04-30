using UnityEngine;
namespace MyBird
{
    //게임 전체플로우를 관리
    // 대기-이동-죽음
    public class GameManager : MonoBehaviour
    {

        #region Property
        public static bool IsStart { get; set; }

        public static bool IsDeath { get; set; }

        public static int Score { get; set; }
        public static int BestScore { get; set; }
        #endregion
        private void Start()
        {
            //최고 점수 가져오기
            BestScore = PlayerPrefs.GetInt("BestScore",0);
            

            IsStart = false;
            IsDeath = false;
            Score = 0;

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void Die()
        {
            //죽음 체크
            
            if (!IsDeath)
            {
                IsDeath = true;
                Debug.Log("게임 오버!");
              
                Destroy(this.gameObject, 0f);
            }

                      
           
        }
    }
}