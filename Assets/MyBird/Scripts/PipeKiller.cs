using UnityEngine;
namespace MyBird
{
    public class PipeKiller : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //collsion 충돌 정보 가져오기
            Destroy(collision.gameObject);


        }

    }

}