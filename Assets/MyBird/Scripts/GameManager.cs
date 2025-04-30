using UnityEngine;
namespace MyBird
{
    //���� ��ü�÷ο츦 ����
    // ���-�̵�-����
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
            //�ְ� ���� ��������
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
            //���� üũ
            
            if (!IsDeath)
            {
                IsDeath = true;
                Debug.Log("���� ����!");
              
                Destroy(this.gameObject, 0f);
            }

                      
           
        }
    }
}