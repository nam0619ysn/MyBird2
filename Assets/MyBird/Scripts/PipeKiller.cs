using UnityEngine;
namespace MyBird
{
    public class PipeKiller : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //collsion �浹 ���� ��������
            Destroy(collision.gameObject);


        }

    }

}